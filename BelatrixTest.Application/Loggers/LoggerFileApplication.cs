using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BelatrixTest.Application.Interface.Loggers;
using BelatrixTest.Common;
using BelatrixTest.Domain.Log;

namespace BelatrixTest.Application.Loggers
{
    public class LoggerFileApplication : ILogDestinationApplication
    {
        private string _fileURL = "";
        private string _fileLocation = "";

        public LoggerFileApplication()
        {
            _fileLocation = ConfigurationManager.AppSettings["LogFileDirectory"]; 
            _fileURL = Path.Combine(_fileLocation, "LogFile_" + DateTime.Now.ToString("yyyy-MM-dd") + ".txt");
        }

        public void WriteLog(LogMessage logMessage, List<LogHelper.LogType> _canBeLogged)
        {
            if (_canBeLogged.Contains(logMessage.Type))
            {
                ValidateURL();

                string fileContent = "";
                if (File.Exists(_fileURL))
                {
                    //get contents and append data
                    fileContent = File.ReadAllText(_fileURL);
                }

                fileContent += string.Format("{0}{1}", DateTime.Now.ToShortDateString(), logMessage.Message) + Environment.NewLine;
                File.WriteAllText(_fileURL, fileContent);
            }
        }

        private void ValidateURL()
        {


            if (string.IsNullOrEmpty(_fileURL))
            {
                throw new ArgumentNullException(Constant.Validation.MissingFile);
            }
            
            if (!Directory.Exists(_fileLocation))
                Directory.CreateDirectory(_fileLocation);

        }
        
    }
}
