using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BelatrixTest.Application;
using BelatrixTest.Application.Interface;
using BelatrixTest.Application.Interface.Loggers;
using BelatrixTest.Application.Loggers;
using BelatrixTest.Common;
using BelatrixTest.Controller.Interface;
using BelatrixTest.Domain.Log;

namespace BelatrixTest.Controller
{
    public class LogController : ILogger
    {
        #region Properties
        
        private ILogDestinationApplication _loggerConsole;
        public ILogDestinationApplication LoggerConsole
        {
            get { return _loggerConsole ?? (_loggerConsole = new LoggerConsoleApplication()); }
            set { _loggerConsole = value; }
        }
        private ILogDestinationApplication _loggerFile;
        public ILogDestinationApplication LoggerFile
        {
            get { return _loggerFile ?? (_loggerFile = new LoggerFileApplication()); }
            set { _loggerFile = value; }
        }
        private ILogDestinationApplication _loggerDataBase;
        public ILogDestinationApplication LoggerDataBase
        {
            get { return _loggerDataBase ?? (_loggerDataBase = new LoggerDataBaseApplication()); }
            set { _loggerDataBase = value; }
        }

        public bool LogToFile { get; private set; }
        public bool LogToConsole { get; private set; }
        public bool LogToDatabase { get; private set; }

        private bool _logOnlyErrors;
        #endregion

        public LogController(bool logToConsole, bool logToFile, bool logToDatabase, bool logOnlyErrors)
        {
            LogToFile = logToFile;
            LogToConsole = logToConsole;
            LogToDatabase = logToDatabase;
            _logOnlyErrors = logOnlyErrors;
        }

        #region Methods

        public void LogAsMessage(string message)
        {
            LogMessage(message, LogHelper.LogType.Message);
        }

        public void LogAsWarning(string message)
        {
            LogMessage(message, LogHelper.LogType.Warning);
        }

        public void LogAsError(string message)
        {
            LogMessage(message, LogHelper.LogType.Error);
        }

        public void LogMessage(string message, LogHelper.LogType logType)
        {

            if (string.IsNullOrWhiteSpace(message))
                return;
            message = message.Trim();

            ValidateLogDestination();

            var logMessage = new LogMessage()
            {
             Message   = message,
             Type = logType
            };

            if (LogToConsole)
                WriteMessage(logMessage, LoggerConsole);
            if (LogToFile)
                WriteMessage(logMessage, LoggerFile);
            if (LogToDatabase)
                WriteMessage(logMessage, LoggerDataBase);

        }

        public void WriteMessage(LogMessage logMessage, ILogDestinationApplication logDestination)
        {
            logDestination.WriteLog(logMessage, typesThatCanBeLogged());
        }
        private List<LogHelper.LogType> typesThatCanBeLogged()
        {
            List<LogHelper.LogType> types = new List<LogHelper.LogType>();

            types.Add(LogHelper.LogType.Message);
            if (_logOnlyErrors)
            {
                types.Add(LogHelper.LogType.Error);
            }
            else
            {
                types.Add(LogHelper.LogType.Warning);
                types.Add(LogHelper.LogType.Error);
            }
            return types;
        }

        private void ValidateLogDestination()
        {
            if (AllConfigurationNotInFalse())
                return;
            throw new Exception(Constant.Validation.InvalidConfig);
        }
        private bool AllConfigurationNotInFalse()
        {
            return LogToConsole
                   || LogToFile
                   || LogToDatabase;
        }
        
        #endregion


    }
}
