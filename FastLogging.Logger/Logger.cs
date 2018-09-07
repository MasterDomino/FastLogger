using System.IO;

namespace FastLogging
{
    public class Logger : ILogger
    {
        public LogLevel LogLevel = LogLevel.ALL;

        private readonly StreamWriter _streamWriter;

        public string LogFilePath = "log.log";

        public Logger(string logFilePath)
        {
            LogFilePath = logFilePath;
            _streamWriter = new StreamWriter(LogFilePath, true);
        }

        public Logger(string logFilePath, LogLevel logLevel) : this(logFilePath) => LogLevel = logLevel;
    }
}
