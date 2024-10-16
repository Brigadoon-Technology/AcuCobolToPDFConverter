// File: IRecordExtractor.cs
using System.Collections.Generic;
using System.Threading.Tasks;
using AcuCobolToPDFConverter.Models;

namespace AcuCobolToPDFConverter.Interfaces
{
    /// <summary>
    /// Defines a contract for record extraction, allowing different implementations for various sources
    /// like files, databases, or web services.
    /// </summary>
    public interface IRecordExtractor
    {
        /// <summary>
        /// Asynchronously extracts records.
        /// </summary>
        /// <returns>A task that represents the asynchronous operation and contains a list of extracted records.</returns>
        Task<List<RecordModel>> ExtractRecords();
    }
}
