using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BelatrixTest.Domain.Log;

namespace BelatrixTest.UnitTest.Injectors
{
    public class TestResult
    {
        public string Message { get; set; }
        public LogHelper.LogType? LogType { get; set; }
    }
}
