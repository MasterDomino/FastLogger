using System;

namespace FastLogging
{
    public interface ILog
    {
        #region Methods

        void Debug(string message, string memberName = "");

        void Error(string message, Exception ex = null, string memberName = "");

        void Fatal(string message, Exception ex = null, string memberName = "");

        void Info(string message, string memberName = "");

        void Warn(string message, Exception ex = null, string memberName = "");

        #endregion
    }
}