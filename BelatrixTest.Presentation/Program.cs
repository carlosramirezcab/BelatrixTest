using System;
using BelatrixTest.Common;
using BelatrixTest.Controller;

namespace BelatrixTest.Presentation
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var logToConsole = true;
            var logToFile = true;
            var logToDatabase = true;
            var logOnlyErrors = true;

            var logController = new LogController(logToConsole, logToFile, logToDatabase, logOnlyErrors);

            logController.LogAsMessage("This is a Message");
            logController.LogAsWarning("This is a Warning message");
            logController.LogAsError("This is an Error message");

        }
    }
}
