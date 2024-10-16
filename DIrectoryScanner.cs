using System;
using System.Collections.Generic;
using System.IO;

namespace AcuCobolToPDFConverter
{
    /// <summary>
    /// Provides methods to scan directories and identify files for processing.
    /// </summary>
    public static class DirectoryScanner
    {
        /// <summary>
        /// Scans the specified directory and returns a list of file paths.
        /// </summary>
        /// <param name="directoryPath">The path of the directory to scan.</param>
        /// <returns>A list of file paths present in the directory.</returns>
        public static List<string> ScanDirectory(string directoryPath)
        {
            if (!Directory.Exists(directoryPath))
            {
                throw new DirectoryNotFoundException($"The directory {directoryPath} does not exist.");
            }

            // Get all files in the directory (you can adjust this to filter specific types if needed)
            var files = Directory.GetFiles(directoryPath);

            Console.WriteLine($"Found {files.Length} files in directory {directoryPath}.");

            return new List<string>(files);
        }
    }
}
