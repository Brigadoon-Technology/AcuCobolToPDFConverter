// File: Program.cs
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
        /// <param name="args">Command line arguments (not used).</param>
        /// <returns>A task representing the asynchronous operation.</returns>
        static async Task Main(string[] args)
        {
            Console.WriteLine("Starting Acucobol record extraction and PDF conversion...");

            // Define the file path where Acucobol records are stored (this can be updated to the actual file path)
            string acucobolFilePath = @"path\to\acucobol\file";

            // Start the extraction and conversion process
            await RecordProcessor.ExtractAndConvertRecords(acucobolFilePath);

            Console.WriteLine("Process complete.");
        }
    }
}
