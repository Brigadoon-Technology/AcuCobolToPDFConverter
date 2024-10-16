// File: RecordProcessor.cs
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AcuCobolToPDFConverter.Models;

namespace AcuCobolToPDFConverter
{
    /// <summary>
    /// Provides methods for processing AcuCobol records, including extraction and PDF conversion.
    /// </summary>
    public static class RecordProcessor
    {
        /// <summary>
        /// Asynchronously extracts records from a specified file path and converts them to PDFs.
        /// </summary>
        /// <param name="filePath">The path to the file containing AcuCobol records.</param>
        /// <returns>A task representing the asynchronous operation.</returns>
        public static async Task ExtractAndConvertRecords(string filePath)
        {
            // Extract records using the AcuCobolInterface
            List<RecordModel> records = await AcuCobolInterface.ExtractRecords(filePath);

            // Specify the output directory for PDFs
            string outputDirectory = @"path\to\output\directory";

            // Generate PDFs for the extracted records
            PDFGenerator.GeneratePDFs(records, outputDirectory);

            // Update the log call
            Logger.LogMessage("Extraction and conversion process completed.");
        }
    }
}
