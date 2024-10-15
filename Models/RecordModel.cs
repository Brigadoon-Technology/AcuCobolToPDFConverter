namespace AcuCobolToPDFConverter.Models
{
    /// <summary>
    /// Represents a single record extracted from the COBOL system.
    /// Adjust the properties to match the actual COBOL record structure.
    /// </summary>
    public class RecordModel
    {
        /// <summary>
        /// Unique identifier for the record.
        /// </summary>
        public int RecordId { get; set; }

        /// <summary>
        /// Name or title of the record.
        /// </summary>
        public string RecordName { get; set; } = string.Empty; // Initialize to empty string

        /// <summary>
        /// Date associated with the record.
        /// </summary>
        public DateTime RecordDate { get; set; } = DateTime.MinValue; // Initialize to a default date

        /// <summary>
        /// Main data of the record, this could represent a description, details, or content.
        /// </summary>
        public string RecordData { get; set; } = string.Empty; // Initialize to empty string

        /// <summary>
        /// Additional metadata or attributes from the COBOL system.
        /// </summary>
        public string Metadata { get; set; } = string.Empty; // Initialize to empty string
    }
}
