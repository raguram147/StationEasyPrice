using StationEasyPrice.Models;

namespace StationEasyPrice.Interfaces
{
    public interface IStationService
    {
        Task<List<StationData>> GetStations();
    }
}
