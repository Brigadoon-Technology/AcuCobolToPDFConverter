// File: PDFGenerator.cs
using System;
using System.Collections.Generic;
using System.IO;
using iText.Kernel.Pdf;
using iText.Layout;
using iText.Layout.Element;
using AcuCobolToPDFConverter.Models;

namespace AcuCobolToPDFConverter
{
    /// <summary>
    /// Provides methods for generating PDF documents from AcuCobol records.
    /// </summary>
    public static class PDFGenerator
    {
        /// <summary>
        /// Generates a PDF for each record in the provided list of records.
        /// Each PDF is saved in the specified output directory.
        /// </summary>
        /// <param name="records">A list of <see cref="RecordModel"/> objects to convert to PDF.</param>
        /// <param name="outputDirectory">The directory to save the generated PDFs.</param>
        public static void GeneratePDFs(List<RecordModel> records, string outputDirectory)
        {
            if (!Directory.Exists(outputDirectory))
            {
                Directory.CreateDirectory(outputDirectory);
            }

            foreach (var record in records)
            {
                string filePath = Path.Combine(outputDirectory, $"Record_{record.RecordId}.pdf");

                using (var writer = new PdfWriter(filePath))
                using (var pdf = new PdfDocument(writer))
                using (var document = new Document(pdf))
                {
                    document.Add(new Paragraph($"Record ID: {record.RecordId}"));
                    document.Add(new Paragraph($"Record Name: {record.RecordName}"));
                    document.Add(new Paragraph($"Record Date: {record.RecordDate.ToString("yyyy-MM-dd")}"));
                    document.Add(new Paragraph($"Record Data: {record.RecordData}"));
                    document.Add(new Paragraph($"Metadata: {record.Metadata}"));
                }

                Console.WriteLine($"PDF generated for Record ID: {record.RecordId} at {filePath}");
            }
        }
    }
}
