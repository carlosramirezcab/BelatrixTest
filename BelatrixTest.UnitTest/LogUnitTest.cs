using System;
using System.Linq.Expressions;
using BelatrixTest.Application;
using BelatrixTest.Application.Interface;
using BelatrixTest.Application.Interface.Loggers;
using BelatrixTest.Common;
using BelatrixTest.Controller;
using BelatrixTest.Domain.Log;
using BelatrixTest.UnitTest.Injectors;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BelatrixTest.UnitTest
{
    [TestClass]
    public class LogUnitTest
    {
        [TestMethod]
        public void TestConsoleLog()
        {
            ILogDestinationApplication consoleWriterInjector = new ConsoleTest();
            ILogDestinationApplication fileWriterInjector = new FileTest();
            ILogDestinationApplication dataBaseWriterInjector = new DataBaseTest();

            var logController = new LogController(true, false, false, false)
            {
                LoggerConsole = consoleWriterInjector,
                LoggerFile = fileWriterInjector,
                LoggerDataBase = dataBaseWriterInjector
            };

            //Set ID x set

            logController.LogAsMessage("Test Message");
            logController.LogAsWarning("Test Warning Message");
            logController.LogAsError("Test Error Message");

            Assert.AreEqual(((DataBaseTest)dataBaseWriterInjector).GetResults().Count, 0);
            Assert.AreEqual(((FileTest)fileWriterInjector).GetResults().Count, 0);
            Assert.AreEqual(((ConsoleTest)consoleWriterInjector).GetResults().Count, 3);
        }

        [TestMethod]
        public void TestFileLog()
        {
            ILogDestinationApplication consoleWriterInjector = new ConsoleTest();
            ILogDestinationApplication fileWriterInjector = new FileTest();
            ILogDestinationApplication dataBaseWriterInjector = new DataBaseTest();

            var logController = new LogController(false, true, false, false)
            {
                LoggerConsole = consoleWriterInjector,
                LoggerFile = fileWriterInjector,
                LoggerDataBase = dataBaseWriterInjector
            };

            //Set ID x set

            logController.LogAsMessage("Test Message");
            logController.LogAsWarning("Test Warning Message");
            logController.LogAsError("Test Error Message");


            Assert.AreEqual(((DataBaseTest)dataBaseWriterInjector).GetResults().Count, 0);
            Assert.AreEqual(((FileTest)fileWriterInjector).GetResults().Count, 3);
            Assert.AreEqual(((ConsoleTest)consoleWriterInjector).GetResults().Count, 0);
        }

        [TestMethod]
        public void TestDataBaseLog()
        {
            ILogDestinationApplication consoleWriterInjector = new ConsoleTest();
            ILogDestinationApplication fileWriterInjector = new FileTest();
            ILogDestinationApplication dataBaseWriterInjector = new DataBaseTest();

            var logController = new LogController(false, false, true, false)
            {
                LoggerConsole = consoleWriterInjector,
                LoggerFile = fileWriterInjector,
                LoggerDataBase = dataBaseWriterInjector
            };

            //Set ID x set

            logController.LogAsMessage("Test Message");
            logController.LogAsWarning("Test Warning Message");
            logController.LogAsError("Test Error Message");

            Assert.AreEqual(((DataBaseTest)dataBaseWriterInjector).GetResults().Count, 3);
            Assert.AreEqual(((FileTest)fileWriterInjector).GetResults().Count, 0);
            Assert.AreEqual(((ConsoleTest)consoleWriterInjector).GetResults().Count, 0);
        }
    }
}
