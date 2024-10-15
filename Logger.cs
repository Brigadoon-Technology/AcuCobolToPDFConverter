using System;
using Serilog;

namespace AcuCobolToPDFConverter
{
    /// <summary>
    /// Provides logging functionality for the application using Serilog.
    /// </summary>
    public static class Logger
    {
        /// <summary>
        /// Initializes the logger with specified configurations.
        /// Sets the minimum log level and specifies log outputs (console and file).
        /// </summary>
        public static void Initialize()
        {
            Log.Logger = new LoggerConfiguration()
                .MinimumLevel.Information() // Specify minimum log level
                .WriteTo.Console()
                .WriteTo.File("logs/log.txt", rollingInterval: RollingInterval.Day)
                .CreateLogger();

            Log.Information("Logger initialized.");
        }

        /// <summary>
        /// Logs an informational message to the log.
        /// </summary>
        /// <param name="message">The message to log.</param>
        public static void LogMessage(string message) // Renamed method
        {
            Log.Information(message); // Correctly calls the Information method
        }

        /// <summary>
        /// Logs an error message to the log.
        /// </summary>
        /// <param name="message">The error message to log.</param>
        public static void LogError(string message)
        {
            Log.Error(message); // Correctly calls the Error method
        }
    }
}
