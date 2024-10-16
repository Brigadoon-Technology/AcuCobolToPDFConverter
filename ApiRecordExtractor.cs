// File: ApiRecordExtractor.cs
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using AcuCobolToPDFConverter.Models;
using AcuCobolToPDFConverter.Interfaces;

namespace AcuCobolToPDFConverter.Connectors
{
    /// <summary>
    /// Extracts records from an external web service (API).
    /// </summary>
    public class ApiRecordExtractor : IRecordExtractor
    {
        private readonly string _apiUrl;
        private static readonly HttpClient _client = new HttpClient();

        /// <summary>
        /// Initializes a new instance of the <see cref="ApiRecordExtractor"/> class.
        /// </summary>
        /// <param name="apiUrl">The URL of the web service to retrieve records from.</param>
        public ApiRecordExtractor(string apiUrl)
        {
            _apiUrl = apiUrl;
        }

        /// <summary>
        /// Asynchronously extracts records from the web service (API).
        /// </summary>
        /// <returns>A task that represents the asynchronous operation and contains a list of extracted records.</returns>
        public async Task<List<RecordModel>> ExtractRecords()
        {
            var response = await _client.GetAsync(_apiUrl);
            if (response.IsSuccessStatusCode)
            {
                var json = await response.Content.ReadAsStringAsync();
                var records = JsonSerializer.Deserialize<List<RecordModel>>(json);
                return records ?? new List<RecordModel>();
            }
            else
            {
                throw new HttpRequestException($"Error fetching records from API: {response.StatusCode}");
            }
        }
    }
}
