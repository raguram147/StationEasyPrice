using StationEasyPrice.Interfaces;
using StationEasyPrice.Models;

namespace StationEasyPrice.Services
{
    public class StationService : IStationService
    {
        private readonly ICsvService _csvService;
        private readonly string _csvFilePath;
        public StationService(ICsvService csvService, IConfiguration configuration)
        {
            _csvService = csvService;
            _csvFilePath = configuration["FileSettings:CsvFilePath"];
        }

        public async Task<List<StationData>> GetStations()
        {
            return await _csvService.ReadCsv(_csvFilePath);
        }
    }
}
