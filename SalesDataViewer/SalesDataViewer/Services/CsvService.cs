using CsvHelper.Configuration;
using CsvHelper;
using SalesDataViewer.Models;
using System.Globalization;
using SalesDataViewer.Helpers;

namespace SalesDataViewer.Services
{
    public class CsvService
    {
        private readonly HttpClient _httpClient;

        public CsvService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<SalesRecord>> GetSalesRecordsAsync(string filePath)
        {
            var stream = await _httpClient.GetStreamAsync(filePath);
            using var reader = new StreamReader(stream);
            using var csv = new CsvReader(reader, new CsvConfiguration(CultureInfo.InvariantCulture)
            {
                HeaderValidated = null,
                MissingFieldFound = null
            });

            csv.Context.RegisterClassMap<SalesMap>();
            var records = new List<SalesRecord>();
            await foreach (var record in csv.GetRecordsAsync<SalesRecord>())
            {
                records.Add(record);
            }

            return records;
        }
    }
}
