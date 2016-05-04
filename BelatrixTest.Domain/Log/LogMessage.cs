using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BelatrixTest.Domain.Log
{
    public class LogMessage
    {
        public string Message { get; set; }
        public LogHelper.LogType Type { get; set; }
    }
}
