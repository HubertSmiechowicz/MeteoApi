using MeteoApi.Models.FiveDays.dtos;
using MeteoApi.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace MeteoApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class FiveDaysForecastController : Controller
    {
        private IFiveDaysForecastService _service;

        public FiveDaysForecastController(IFiveDaysForecastService service)
        {
            _service = service;
        }

        [HttpGet]
        public FiveDaysForecastDto GetFiveDaysForecast([FromQuery] string cityName)
        {
            return _service.GetFiveDaysForecast(cityName);
        }
    }
}
