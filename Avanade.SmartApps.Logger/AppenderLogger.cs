using log4net;
using log4net.Appender;
using log4net.Core;
using System;
using System.Diagnostics;
using System.IO;
using System.Net;

namespace Avanade.SmartApps.Logger
{
    class AppenderLogger : AppenderSkeleton
    {
        private SaveAsynchronous _salvar;

        protected override void Append(LoggingEvent loggingEvent)
        {
            try
            {
                Log _log = new Log();
                string message = RenderLoggingEvent(loggingEvent);
                string maquina = Dns.GetHostName();
                IPAddress[] ip = Dns.GetHostAddresses(maquina);

                _log.IdCorrelacao = LogicalThreadContext.Properties["CorrelationId"].ToString();
                _log.DataHora = DateTime.Now;
                _log.Ip = ip[1].ToString();
                _log.Maquina = maquina;
                _log.Usuario = loggingEvent.Identity;
                _log.SistemaOrigem = _sourcesystem;
                _log.Tipo = loggingEvent.Level.Name;
                _log.Dados = message;

                //Salva Fila Assincrono
                if (_salvar == null)
                {
                    _salvar = new SaveAsynchronous(ConsumeAsynchronous, "ThreadLog", System.Threading.ThreadPriority.Normal, true);
                }
                _salvar.Save(_log);

            }
            catch (Exception ex)
            {
                //TODO: Erro na gravacao da fila???
            }
        }

        string _filecontingenciaserver;

        public string FileContingenciaServer
        {
            set { _filecontingenciaserver = value; }
        }

        string _filecontingenciaclient;

        public string FileContingenciaClient
        {
            set { _filecontingenciaclient = value; }
        }

        string _sourcesystem;

        public string SourceSystem
        {
            set { _sourcesystem = value; }
        }

        /// <summary>
        /// Delegate utilizado para a gravação assíncrona. Sempre que uma gravação deve ser feita
        /// esse delegate é invocado com o item a ser salvo
        /// </summary>
        /// <param name="item">Ítem a ser salvo</param>
        private void ConsumeAsynchronous(object item)
        {
            Log _logItem = (Log)item;
            LoggingSDKDAL src = new LoggingSDKDAL();
            LoggingSDKDAL.ReturnLog rtn = new LoggingSDKDAL.ReturnLog();
            
            rtn = src.SaveLogCRM(_logItem);

            if (rtn.Sucess == false)
            {
                WriteLogToFile(_logItem, rtn.Ex);
            }
        }

        private void WriteLogToFile(Log _logItem, Exception ExFromCrm)
        {
            try
            {
                string _filePath;

                if (_sourcesystem == "Plugin" || _sourcesystem == "WCF") _filePath = _filecontingenciaserver;
                else _filePath = _filecontingenciaclient;

                //Create directory if dosent exists
                if (!File.Exists(_filePath)) (new FileInfo(_filePath)).Directory.Create();

                //Write in log file
                using (System.IO.StreamWriter LogFile = new System.IO.StreamWriter(_filePath, true))
                {
                    LogFile.Write(_logItem.Dados);
                    LogFile.WriteLine(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + " - ERROR - Append - Error while trying to save log with CRM SDK: \n" + ExFromCrm);
                }
            }
            catch (Exception ex)
            {
                WriteLogToEvent(_logItem, ExFromCrm, ex);
            }
        }

        private void WriteLogToEvent(Log _logItem, Exception ExFromCrm, Exception ExFromWriteFile)
        {
            try
            {
                string sSource = "CieloSirius";

                if (!EventLog.SourceExists(sSource)) EventLog.CreateEventSource(sSource, "Logger");

                EventLog.WriteEntry(sSource, _logItem.Dados, EventLogEntryType.Error);

                EventLog.WriteEntry(sSource, ExFromCrm.Message, EventLogEntryType.Error);

                EventLog.WriteEntry(sSource, ExFromWriteFile.Message, EventLogEntryType.Error);
                
            }
            catch
            {
                //This is the last contigency level
            }
        }
    }
}
