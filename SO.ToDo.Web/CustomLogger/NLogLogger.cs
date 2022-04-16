using NLog;
using LogLevel = NLog.LogLevel;

namespace SO.ToDo.Web.CustomLogger
{
    public class NLogLogger
    {
        public void LogWithNLog(string message)
        {
            //NLog.config can editable in project folder
            var logger = LogManager.GetLogger("mylogger");
            logger.Log(LogLevel.Error, message: message);
        }
    }
}
