using System;

namespace FastLogging.TestConsole
{
    internal static class Program
    {
        #region Methods

        private static void Main()
        {
            Logger.InitializeLogger(new Log(typeof(Program), LogLevel.ALL));
            Logger.Info("Logger initialized!");
            Logger.Debug("Test debug message.");
            Logger.Info("Test info message.");
            Logger.Warn("Test warn message.");
            Logger.Error("Test error message.");
            Logger.Fatal("Test fatal message.");
            Logger.Info("Test finished.");
            Logger.Log.PrepareShutdown();
            Console.ReadKey();
        }

        #endregion
    }
}