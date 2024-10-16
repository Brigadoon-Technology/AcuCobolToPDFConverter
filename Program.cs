using System;
using System.Threading.Tasks;

namespace AcuCobolToPDFConverter
{
    /// <summary>
    /// Entry point for the AcuCobolToPDFConverter application.
    /// </summary>
    class Program
    {
        /// <summary>
        /// Main method that starts the application.
        /// </summary>
        /// <param name="args">Command line arguments.</param>
        /// <returns>A task representing the asynchronous operation.</returns>
        static async Task Main(string[] args)
        {
            // Initialize the logger
            Logger.Initialize();

            Console.WriteLine("Starting AcuCobol record extraction and PDF conversion...");

            // Define the directory path to scan
            string directoryPath = @"path\to\acucobol\directory";

            try
            {
                // Step 1: Scan the directory to identify and group files
                var files = DirectoryScanner.ScanDirectory(directoryPath);

                // Step 2: Process each file
                foreach (var filePath in files)
                {
                    await RecordProcessor.ExtractAndConvertRecords(filePath);
                }

                Logger.LogMessage("All files processed successfully.");
            }
            catch (Exception ex)
            {
                Logger.LogError($"Error occurred during processing: {ex.Message}");
            }

            Console.WriteLine("Process complete.");
        }
    }
}
