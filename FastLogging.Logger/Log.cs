using System;
using System.IO;

namespace FastLogging
{
    public class Log : ILog, IDisposable
    {
        #region Members

        private readonly string _logFilePath = "log.log";
        private readonly string _loggerName = "DefaultLogger";
        private readonly LogLevel _logLevel = LogLevel.ALL;
        private readonly StreamWriter _streamWriter;
        private bool _disposed;
        private Type _loggerType;

        #endregion

        #region Instantiation

        public Log(string logFilePath)
        {
            _logFilePath = logFilePath;
            _streamWriter = new StreamWriter(_logFilePath, true);
        }

        public Log(string logFilePath, LogLevel logLevel) : this(logFilePath) => _logLevel = logLevel;

        public Log(Type loggerType, string logFilePath, LogLevel logLevel) : this(logFilePath, logLevel)
        {
            _loggerType = loggerType;
            _loggerName = loggerType.Namespace.RemoveBefore('.');
        }

        public Log(Type loggerType, LogLevel logLevel)
        {
            _logLevel = logLevel;
            _loggerType = loggerType;
            _loggerName = loggerType.Namespace.RemoveBefore('.');
            _streamWriter = new StreamWriter(_logFilePath, true);
        }

        #endregion

        #region Methods

        public void Debug(string message, string memberName = "")
        {
            if (!string.IsNullOrWhiteSpace(message))
            {
                Append(message, memberName, LogLevel.DEBUG);
            }
        }

        public void Dispose() => Dispose(true);

        public void Error(string message, Exception ex = null, string memberName = "")
        {
            if (!string.IsNullOrWhiteSpace(message))
            {
                if (ex == null)
                {
                    Append(message, memberName, LogLevel.ERROR);
                }
                else
                {
                    Append(message + Environment.NewLine + ex.Message + Environment.NewLine + ex.StackTrace, memberName, LogLevel.ERROR);
                }
            }
        }

        public void Fatal(string message, Exception ex = null, string memberName = "")
        {
            if (!string.IsNullOrWhiteSpace(message))
            {
                if (ex == null)
                {
                    Append(message, memberName, LogLevel.FATAL);
                }
                else
                {
                    Append(message + Environment.NewLine + ex.Message + Environment.NewLine + ex.StackTrace, memberName, LogLevel.FATAL);
                }
            }
        }

        public void Info(string message, string memberName = "")
        {
            if (!string.IsNullOrWhiteSpace(message))
            {
                Append(message, memberName, LogLevel.INFO);
            }
        }

        public void Warn(string message, Exception ex = null, string memberName = "")
        {
            if (!string.IsNullOrWhiteSpace(message))
            {
                if (ex == null)
                {
                    Append(message, memberName, LogLevel.WARN);
                }
                else
                {
                    Append(message + Environment.NewLine + ex.Message + Environment.NewLine + ex.StackTrace, memberName, LogLevel.WARN);
                }
            }
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {
                    _streamWriter.Close();
                    _streamWriter.Dispose();
                }
                _loggerType = null;
                _disposed = true;
            }
        }

        private void Append(string message, string memberName, LogLevel logLevel)
        {
            if (memberName?.Length == 0)
            {
                AppendToConsole(message, logLevel);
                AppendToFile(message, logLevel);
            }
            else
            {
                AppendToConsole("[" + memberName + "]: " + message, logLevel);
                AppendToFile("[" + memberName + "]: " + message, logLevel);
            }
        }

        private void AppendToConsole(string message, LogLevel logLevel)
        {
            switch (logLevel)
            {
                case LogLevel.DEBUG:
                    Console.ForegroundColor = ConsoleColor.Magenta;
                    break;

                case LogLevel.INFO:
                    Console.ForegroundColor = ConsoleColor.Green;
                    break;

                case LogLevel.WARN:
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    break;

                case LogLevel.ERROR:
                    Console.ForegroundColor = ConsoleColor.Red;
                    break;

                case LogLevel.FATAL:
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    break;
            }
            Console.WriteLine("[" + DateTime.Now.ToString("HH:mm:ss") + "][" + logLevel.ToString() + "]" + message);
            Console.ResetColor();
        }

        private void AppendToFile(string message, LogLevel logLevel)
        {
            if (logLevel <= _logLevel)
            {
                _streamWriter.WriteLine("[" + DateTime.Now.ToString("MM.dd.yyyy H:mm:ss") + "][" + _loggerName + "][" + logLevel.ToString() + "]" + message);
                _streamWriter.Flush();
            }
        }

        #endregion
    }
}