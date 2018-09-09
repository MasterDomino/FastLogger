using System;
using System.Runtime.CompilerServices;

namespace FastLogging
{
    public static class Logger
    {
        #region Properties

        public static ILog Log { get; set; }

        #endregion

        #region Methods

        public static void Debug(string message, [CallerMemberName] string memberName = "") => Log.Debug(message, memberName);

        public static void Error(string message, Exception ex = null, [CallerMemberName] string memberName = "") => Log.Error(message, ex, memberName);

        public static void Fatal(string message, Exception ex = null, [CallerMemberName] string memberName = "") => Log.Fatal(message, ex, memberName);

        public static void Info(string message, [CallerMemberName] string memberName = "") => Log.Info(message, memberName);

        public static void InitializeLogger(ILog log) => Log = log;

        public static void Warn(string message, Exception ex = null, [CallerMemberName] string memberName = "") => Log.Warn(message, ex, memberName);

        #endregion
    }
}