// File: DatabaseRecordExtractor.cs
using System;
using System.Collections.Generic;
using System.Data.Odbc;
using System.Threading.Tasks;
using AcuCobolToPDFConverter.Models;
using AcuCobolToPDFConverter.Interfaces;

namespace AcuCobolToPDFConverter.Connectors
{
    /// <summary>
    /// Extracts records from a database using an ODBC connection.
    /// </summary>
    public class DatabaseRecordExtractor : IRecordExtractor
    {
        private readonly string _connectionString;

        /// <summary>
        /// Initializes a new instance of the <see cref="DatabaseRecordExtractor"/> class.
        /// </summary>
        /// <param name="connectionString">The ODBC connection string to the database.</param>
        public DatabaseRecordExtractor(string connectionString)
        {
            _connectionString = connectionString;
        }

        /// <summary>
        /// Asynchronously extracts records from the database.
        /// </summary>
        /// <returns>A task that represents the asynchronous operation and contains a list of extracted records.</returns>
        public async Task<List<RecordModel>> ExtractRecords()
        {
            var records = new List<RecordModel>();
            using (var connection = new OdbcConnection(_connectionString))
            {
                await connection.OpenAsync();
                Console.WriteLine("Connected to database.");

                string query = "SELECT RecordId, RecordName, RecordDate, RecordData FROM Records";

                using (var command = new OdbcCommand(query, connection))
                using (var reader = await command.ExecuteReaderAsync())
                {
                    while (await reader.ReadAsync())
                    {
                        var record = new RecordModel
                        {
                            RecordId = reader.GetInt32(0),
                            RecordName = reader.GetString(1),
                            RecordDate = reader.GetDateTime(2),
                            RecordData = reader.GetString(3)
                        };

                        records.Add(record);
                    }
                }
            }
            return records;
        }
    }
}
