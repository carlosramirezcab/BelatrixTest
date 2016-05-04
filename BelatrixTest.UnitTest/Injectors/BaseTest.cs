using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BelatrixTest.Application.Interface.Loggers;
using BelatrixTest.Domain.Log;
using BelatrixTest.UnitTest.Interfaces;

namespace BelatrixTest.UnitTest.Injectors
{
    public class BaseTest : ILogDestinationApplication, ITest
    {
        public void WriteLog(LogMessage logMessage, List<LogHelper.LogType> _canBeLogged)
        {
            _results.Add(new TestResult { Message = logMessage.Message, LogType = logMessage.Type });
        }

        public List<TestResult> GetResults()
        {
            return _results;
        }

        private List<TestResult> _results = new List<TestResult>();
    }
}
