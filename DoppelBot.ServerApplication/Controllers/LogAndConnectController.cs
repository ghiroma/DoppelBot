using DoppelBot.ServerApplication.Constants;
using DoppelBot.ServerApplication.Helpers;
using EZ_B;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace DoppelBot.ServerApplication.Controllers
{
    public class LogAndConnectController
    {
        private LoggerHelper _logger;

        public LogAndConnectController()
        {
            this._logger = new LoggerHelper(LoggerConstants.LOG_FILE_PATH);
        }

        public string ReadLog()
        {
            return this._logger.ReadLog();
        }

        public string ReadFilteredLog(DateTime? from, DateTime? To)
        {
            var logToReturn = string.Empty;
            var log = this._logger.ReadLogLines();
            foreach (var line in log)
            {
                var dateText = line.Split('|')[0];
                dateText = dateText.Trim();
                var date = Convert.ToDateTime(dateText);
                if (from != null && date.CompareTo(from) > 0)
                {
                    if (To != null && date.CompareTo(To) < 0)
                    {
                        logToReturn += line + '\n';
                    }
                    else if (To == null)
                    {
                        logToReturn += line + '\n';
                    }
                }
                else if (To != null && date.CompareTo(To) < 0)
                {
                    logToReturn += line + '\n';
                }
            }

            return logToReturn;
        }
    }
}
