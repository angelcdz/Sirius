using Avanade.SmartApps.Logger;
using log4net;
using System;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Runtime.CompilerServices;
using System.Runtime.Serialization;
using System.Text;
using System.Xml;

namespace Cielo.Sirius.Foundation
{
    public sealed class Logger
    {
        private static ILog log;
        private string sourceSystem;
        private int sourceLineNumber;
        private string defaultMesage = "Log message null";

        public static Logger LoggerFor<T>([CallerFilePath] string system = "")
        {
            return new Logger(typeof(T).Name, system);
        }

        public Logger(string sourceName, [CallerFilePath] string system = "", [CallerLineNumber] int lineNumber = 0)
        {
            if (system.ToUpper().Contains("USD") == true) sourceSystem = "Client";
            if (system.ToUpper().Contains("PLUGIN") == true) sourceSystem = "Plugin";
            if (system.ToUpper().Contains("WCF") == true) sourceSystem = "WCF";
            if (system.ToUpper().Contains("Test") == true) sourceSystem = "Test";

            sourceLineNumber = lineNumber;
        }

        private bool ConfigureLogging()
        {
            try
            {
                if (log == null)
                {
                    Adapter adp = new Adapter();
                    log = adp.ConfigureFileAppender(sourceSystem, sourceLineNumber);
                }
                return true;
            }
            catch (Exception ex)
            {
                LogLocalError(ex);
                return false;
            }
        }

        private void LogLocalError(Exception ex)
        {
            string _filePath = "C:\\LogCRM2\\LogFromCode4Client.log";

            //Create directory if dosent exists
            if (!File.Exists(_filePath)) (new FileInfo(_filePath)).Directory.Create();

            //Write in log file
            using (System.IO.StreamWriter LogFile = new System.IO.StreamWriter(_filePath, true))
            {
                LogFile.WriteLine(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + " - ERROR - LoggerFacade: \n" + ex);
            }
        }

        public void LogInformation(string message, params object[] args)
        {
            if (ConfigureLogging())
            {
                LogicalThreadContext.Properties["CorrelationId"] = Trace.CorrelationManager.ActivityId.ToString("D", CultureInfo.InvariantCulture);
                log.Info(ValidateStringFormat(message, args));
            }
        }

        public void LogInformation(Exception ex, string message, params object[] args)
        {
            if (ConfigureLogging())
            {
                LogicalThreadContext.Properties["CorrelationId"] = Trace.CorrelationManager.ActivityId.ToString("D", CultureInfo.InvariantCulture);
                log.Info(ValidateStringFormat(message, args), ex);
            }
        }

        public void LogVerbose(string message, params object[] args)
        {
            if (ConfigureLogging())
            {
                LogicalThreadContext.Properties["CorrelationId"] = Trace.CorrelationManager.ActivityId.ToString("D", CultureInfo.InvariantCulture);
                log.Info(ValidateStringFormat(message, args));
            }
        }

        public void LogVerbose(Exception ex, string message, params object[] args)
        {
            if (ConfigureLogging())
            {
                LogicalThreadContext.Properties["CorrelationId"] = Trace.CorrelationManager.ActivityId.ToString("D", CultureInfo.InvariantCulture);
                log.Info(ValidateStringFormat(message, args), ex);
            }
        }

        public void LogError(string message, params object[] args)
        {
            if (ConfigureLogging())
            {
                LogicalThreadContext.Properties["CorrelationId"] = Trace.CorrelationManager.ActivityId.ToString("D", CultureInfo.InvariantCulture);
                log.Error(ValidateStringFormat(message, args));
            }
        }

        public void LogError(Exception ex, string message, params object[] args)
        {
            if (ConfigureLogging())
            {
                LogicalThreadContext.Properties["CorrelationId"] = Trace.CorrelationManager.ActivityId.ToString("D", CultureInfo.InvariantCulture);
                log.Error(ValidateStringFormat(message, args), ex);
            }
        }

        public void LogWarning(string message, params object[] args)
        {
            if (ConfigureLogging())
            {
                LogicalThreadContext.Properties["CorrelationId"] = Trace.CorrelationManager.ActivityId.ToString("D", CultureInfo.InvariantCulture);
                log.Warn(ValidateStringFormat(message, args));
            }
        }

        public void LogWarning(Exception ex, string message, params object[] args)
        {
            if (ConfigureLogging())
            {
                LogicalThreadContext.Properties["CorrelationId"] = Trace.CorrelationManager.ActivityId.ToString("D", CultureInfo.InvariantCulture);
                log.Warn(ValidateStringFormat(message, args), ex);
            }
        }

        private string ValidateStringFormat(string message, object[] args)
        {
            string messageRec;
            try
            {
                messageRec = string.Format(message ?? defaultMesage, args);
            }
            catch
            {
                messageRec = message ?? defaultMesage;
            }
            return messageRec;
        }

        public static string BasicSerialization(object dataObject)
        {
            try
            {
                if (dataObject != null)
                {
                    StringBuilder strbuilder = new StringBuilder();

                    XmlWriter writer = XmlWriter.Create(strbuilder);
                    DataContractSerializer serializer = new DataContractSerializer(dataObject.GetType());
                    serializer.WriteObject(writer, dataObject);
                    writer.Flush();
                    return strbuilder.ToString();
                }

                return string.Empty;
            }
            catch
            {
                return string.Empty;
            }
        }
    }
}
