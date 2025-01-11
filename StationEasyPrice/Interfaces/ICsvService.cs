using StationEasyPrice.Models;

namespace StationEasyPrice.Interfaces
{
    public interface ICsvService
    {
        Task<List<StationData>> ReadCsv(string filePath);
    }
}
