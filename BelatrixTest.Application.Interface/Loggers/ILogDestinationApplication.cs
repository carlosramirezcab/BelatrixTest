using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BelatrixTest.Domain.Log;

namespace BelatrixTest.Application.Interface.Loggers
{
    public interface ILogDestinationApplication
    {
        void WriteLog(LogMessage logMessage, List<LogHelper.LogType> _canBeLogged);
    }
}
