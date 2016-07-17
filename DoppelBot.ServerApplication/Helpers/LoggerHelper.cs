using DoppelBot.ServerApplication.Constants;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoppelBot.ServerApplication.Helpers
{
    public class LoggerHelper
    {
        private string _filePath;

        public LoggerHelper(string filePath)
        {
            this._filePath = filePath;
        }

        public void LogDebug(string message)
        {
            Log(message, LoggerConstants.DEBUG_CATEGORY);
        }

        public void LogInfo(string message)
        {
            Log(message, LoggerConstants.INFO_CATEGORY);
        }

        public void LogCritical(string message)
        {
            Log(message, LoggerConstants.CRITICAL_CATEGORY);
        }

        public void LogError(string message)
        {
            Log(message, LoggerConstants.ERROR_CATEGORY);
        }

        public void Log(string message, string category)
        {
            using (var file = new System.IO.StreamWriter(this._filePath, true))
            {
                file.WriteLine(DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss") + " | " + category + ":" + message);
            }
        }
        
        public string[] ReadLogLines()
        {            
            return System.IO.File.ReadAllLines(this._filePath);
        }

        public string ReadLog()
        {
            if(System.IO.File.Exists(this._filePath))
            {
                return System.IO.File.ReadAllText(this._filePath);
            }
            else
            {
                System.IO.File.CreateText(this._filePath);
                return string.Empty;
            }
        }
    }
}
