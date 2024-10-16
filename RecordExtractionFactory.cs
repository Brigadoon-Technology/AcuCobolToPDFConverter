// File: RecordExtractionFactory.cs
using System;
using AcuCobolToPDFConverter.Interfaces;
using AcuCobolToPDFConverter.Connectors;

namespace AcuCobolToPDFConverter
{
    /// <summary>
    /// Provides a factory pattern for creating record extractors based on the specified source type.
    /// This allows switching between file, database, or API sources for record extraction.
    /// </summary>
    public class RecordExtractionFactory
    {
        /// <summary>
        /// Creates an instance of a record extractor based on the given source type.
        /// </summary>
        /// <param name="sourceType">The type of the source (file, database, or api).</param>
        /// <param name="connectionStringOrFilePath">The connection string, file path, or API URL depending on the source type.</param>
        /// <returns>An implementation of the <see cref="IRecordExtractor"/> interface.</returns>
        public static IRecordExtractor CreateExtractor(string sourceType, string connectionStringOrFilePath)
        {
            return sourceType.ToLower() switch
            {
                "file" => new FileRecordExtractor(connectionStringOrFilePath),
                "database" => new DatabaseRecordExtractor(connectionStringOrFilePath),
                "api" => new ApiRecordExtractor(connectionStringOrFilePath),
                _ => throw new ArgumentException("Invalid source type")
            };
        }
    }
}
