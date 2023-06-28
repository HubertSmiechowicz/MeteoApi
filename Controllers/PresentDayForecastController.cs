using MeteoApi.Services;
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
        public string GetForecastForCity([FromQuery] string cityName)
        {
            return _presentDayForecastService.GetForecastForCity(cityName);
        }
    }
}
