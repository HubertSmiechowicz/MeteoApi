using MeteoApi.Models.Daily.dtos;
using MeteoApi.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace MeteoApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PresentDayForecastController : Controller
    {
        private IPresentDayForecastService _presentDayForecastService;

        public PresentDayForecastController(IPresentDayForecastService presentDayForecastService)
        {
            _presentDayForecastService = presentDayForecastService;
        }

        [HttpGet]
        public PresentDayForecastDto GetForecastForCity([FromQuery] string cityName)
        {
            return _presentDayForecastService.GetForecastForCity(cityName);
        }

        [HttpGet("{cities}")]
        public List<PresentDayForecastSimpleDto> GetSimpleForecastForListOfCities([FromQuery] List<string> cityNames) 
        {
            return _presentDayForecastService.GetSimpleForecastForListOfCities(cityNames);
        }
    }
}
