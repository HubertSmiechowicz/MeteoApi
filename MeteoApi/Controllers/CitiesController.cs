using MeteoApi.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace MeteoApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CitiesController : Controller
    {
        private ICitiesService _citiesService;

        public CitiesController(ICitiesService citiesService)
        {
            _citiesService = citiesService;
        }

        [HttpGet]
        public List<string> GetCities(string cityNameFragment)
        {
            return _citiesService.GetCities(cityNameFragment);
        }

        [HttpGet("{main}")]
        public List<string> GetMainCities()
        {
            return _citiesService.GetMainCities();
        }
    }
}
