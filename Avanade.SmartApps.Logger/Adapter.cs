using log4net;
using log4net.Repository.Hierarchy;
using System;
using System.Linq;
using System.Xml;

namespace Avanade.SmartApps.Logger
{
    public class Adapter
    {
        public ILog ConfigureFileAppender(string sourceSystem = "", int sourceLineNumber = 0)
        {
            string xmlConfig = string.Empty;
            string xmlCustom = string.Empty;

            LoggingSDKDAL src = new LoggingSDKDAL();
            try
            {
                xmlConfig = src.GetCustomCrmConfig();
            }
            catch
            {
                xmlConfig = @"<log4net>
                                <appender name='AppenderLogger' type='Avanade.SmartApps.Logger.AppenderLogger, Avanade.SmartApps.Logger'>
                                  <param name='FileContingenciaServer' value='C:\LogCRM2\LogFromCode4Server.log'/>
                                  <param name='FileContingenciaClient' value='C:\LogCRM2\LogFromCode4Client.log'/>
                                 
                                  <layout type='log4net.Layout.PatternLayout'>
                                    <param name='ConversionPattern' value='%date{yyyy-MM-dd HH:mm:ss} - %-5p - %M - Line: %line %m%n'/>
                                  </layout>
                                </appender>
                                <root>
                                  <level value='Debug'/>
                                  <appender-ref ref='AppenderLogger' />
                                </root>
                              </log4net>";
            }

            XmlDocument doc = new XmlDocument();
            doc.LoadXml(xmlConfig);

            log4net.Config.XmlConfigurator.Configure(doc.DocumentElement);

            // Get the Hierarchy object that organizes the loggers
            Hierarchy hier = log4net.LogManager.GetRepository() as Hierarchy;

            if (hier != null)
            {
                //Get ADONetAppender
                var appenderHierachy = (AppenderLogger)hier.GetAppenders().Where(
                         appender => appender.Name.Equals("AppenderLogger", StringComparison.InvariantCultureIgnoreCase)).FirstOrDefault();

                if (appenderHierachy != null)
                {
                    //Add fields in appender configuration
                    appenderHierachy.SourceSystem = sourceSystem;

                    //refresh settings of appender
                    appenderHierachy.ActivateOptions();
                }
            }

            return LogManager.GetLogger("AppenderLogger");
        }

    }
}
