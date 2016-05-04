using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BelatrixTest.Application.Interface.Loggers;
using BelatrixTest.Common;
using BelatrixTest.Domain.Log;
using BelatrixTest.Repository;

namespace BelatrixTest.Application.Loggers
{
    public class LoggerDataBaseApplication : ILogDestinationApplication
    {
        #region Properties

        private string _connectionString = "";

        private static LogRepository _repository;
        private static readonly object LockObj = new object();

        public LogRepository LogRepository
        {
            get
            {
                if (_repository != null) return _repository;

                lock (LockObj)
                {
                    _repository = new LogRepository(_connectionString);
                }
                return _repository;
            }
        }

        #endregion


        public LoggerDataBaseApplication()
        {
            _connectionString = ConfigurationManager.ConnectionStrings["BelatrixConnection"].ConnectionString;
        }

        public void WriteLog(LogMessage logMessage, List<LogHelper.LogType> _canBeLogged)
        {
            if (_canBeLogged.Contains(logMessage.Type))
            {
                if (string.IsNullOrEmpty(_connectionString))
                {
                    throw new ArgumentNullException(Constant.Validation.MissingConfig);
                }
                LogRepository.LogMessage(logMessage);
            }
        }


    }
}
