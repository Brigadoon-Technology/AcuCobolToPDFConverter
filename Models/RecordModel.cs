// File: RecordModel.cs
namespace AcuCobolToPDFConverter.Models
{
    /// <summary>
    /// Represents a single record extracted from the COBOL system.
    /// This class serves as the data structure to hold the necessary information from a COBOL record.
    /// </summary>
    public class RecordModel
    {
        /// <summary>
        /// Gets or sets the unique identifier for the record.
        /// </summary>
        public int RecordId { get; set; }

        /// <summary>
        /// Gets or sets the name or title of the record.
        /// </summary>
        public string RecordName { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the date associated with the record.
        /// </summary>
        public DateTime RecordDate { get; set; } = DateTime.MinValue;

        /// <summary>
        /// Gets or sets the main data of the record, which could represent a description, details, or content.
        /// </summary>
        public string RecordData { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets additional metadata or attributes from the COBOL system.
        /// </summary>
        public string Metadata { get; set; } = string.Empty;
    }
}
