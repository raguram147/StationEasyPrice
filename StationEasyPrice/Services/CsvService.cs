using System.Globalization;
using CsvHelper;
using CsvHelper.Configuration;
using StationEasyPrice.Converters;
using StationEasyPrice.Interfaces;
using StationEasyPrice.Models;

namespace StationEasyPrice.Services
{
    public class CsvService : ICsvService
    {
        public async Task<List<StationData>> ReadCsv(string filePath)
        {
            var stations = new List<StationData>();

            var config = new CsvConfiguration(CultureInfo.InvariantCulture)
            {
                MissingFieldFound = null,  // Handle missing fields gracefully
                HeaderValidated = null,    // Disable header validation
                BadDataFound = null        // Handle bad data gracefully
            };

            try
            {
                using (var reader = new StreamReader(filePath))
                using (var csv = new CsvReader(reader, config))
                {
                    // Add custom converters for double and decimal types
                    csv.Context.TypeConverterCache.AddConverter<double>(new SafeDoubleConverter());
                    csv.Context.TypeConverterCache.AddConverter<decimal>(new SafeDecimalConverter());

                    // Get records and apply conversions automatically
                    stations = csv.GetRecords<StationData>().ToList();
                }
            }
            catch (CsvHelperException csvEx)
            {
                // Handle CsvHelper-specific exceptions
                Console.WriteLine($"CSV Helper error: {csvEx.Message}");
            }
            catch (Exception ex)
            {
                // General exception handling
                Console.WriteLine($"Error reading CSV file: {ex.Message}");
            }

            return stations;
        }
    }
}
