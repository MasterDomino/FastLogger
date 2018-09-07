using System;

namespace FastLogging.TestConsole
{
    internal static class Program
    {
        private static void Main()
        {
            Logger.InitializeLogger(new Log(typeof(Program), LogLevel.ALL));
            Logger.Info("Logger initialized!");
            Console.ReadKey();
        }
    }
}
