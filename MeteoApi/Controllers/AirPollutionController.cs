using MeteoApi.Models.Air.dtos;
using MeteoApi.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace MeteoApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AirPollutionController : Controller
    {
        private readonly IAirPollutionService _airPollutionService;

        public AirPollutionController(IAirPollutionService airPollutionService)
        {
            _airPollutionService = airPollutionService;
        }

        [HttpGet]
        public AirPollutionDto GetAirPollution([FromQuery]string cityName)
        {
            return _airPollutionService.GetAirPollution(cityName);
        }
    }
}
