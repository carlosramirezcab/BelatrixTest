using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BelatrixTest.Domain.Log;

namespace BelatrixTest.Controller.Interface
{
    public interface ILogger
    {
        void LogAsMessage(string message);
        void LogAsWarning(string message);
        void LogAsError(string message);
        void LogMessage(string message, LogHelper.LogType logType);
    }
}
