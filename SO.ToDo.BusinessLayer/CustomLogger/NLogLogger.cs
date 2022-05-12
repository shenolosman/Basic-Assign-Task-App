using NLog;
using SO.ToDo.BusinessLayer.Interfaces;

namespace SO.ToDo.BusinessLayer.CustomLogger
{
    public class NLogLogger : ICustomLogger
    {
        public void LogError(string message)
        {
            //NLog.config can editable in project folder
            var logger = LogManager.GetLogger("loggerFile");
            logger.Log(LogLevel.Error, message);
        }
    }
}
