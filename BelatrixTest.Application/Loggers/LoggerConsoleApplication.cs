using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BelatrixTest.Application.Interface.Loggers;
using BelatrixTest.Domain.Log;

namespace BelatrixTest.Application.Loggers
{
    public class LoggerConsoleApplication : ILogDestinationApplication
    {
        public void WriteLog(LogMessage logMessage, List<LogHelper.LogType> _canBeLogged)
        {
            if (_canBeLogged.Contains(logMessage.Type))
            {

                if (ConsoleColors.ContainsKey(logMessage.Type))
                    Console.ForegroundColor = ConsoleColors[logMessage.Type];
                Console.WriteLine(string.Format("{0} {1}", DateTime.Now.ToShortDateString(), logMessage.Message));
            }
        }

        private Dictionary<LogHelper.LogType, ConsoleColor> ConsoleColors = new Dictionary<LogHelper.LogType, ConsoleColor>
        {
            {LogHelper.LogType.Message, ConsoleColor.White},
            {LogHelper.LogType.Warning, ConsoleColor.Yellow},
            {LogHelper.LogType.Error, ConsoleColor.Red}
        };
    }
}
