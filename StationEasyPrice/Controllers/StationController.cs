using Microsoft.AspNetCore.Mvc;
using StationEasyPrice.Interfaces;
using StationEasyPrice.Models;

namespace StationEasyPrice.Controllers
{
    public class StationController : Controller
    {
        private readonly IStationService _stationService;

        public StationController(IStationService stationService)
        {
            _stationService = stationService;
        }
        public async Task<IActionResult> Index()
        {
            var stations = await _stationService.GetStations();

            if (stations != null && stations.Any())
            {
                return View(stations);
            }

            return View(new List<StationData>());
        }

    }
}
