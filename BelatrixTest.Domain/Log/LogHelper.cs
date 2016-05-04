using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BelatrixTest.Domain.Log
{
    public class LogHelper
    {
        public enum LogType { Message = 1, Warning = 2, Error = 3 }
        public enum DestinationType { Console = 1, File = 2, DataBase = 3 }
    }
}
