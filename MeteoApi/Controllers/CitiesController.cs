using MeteoApi.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace MeteoApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CitiesController : Controller
    {
        private ICitiesJsonService _citiesJsonService;
        private ICityCollectionService _cityCollectionService;

        public CitiesController(ICitiesJsonService citiesService, ICityCollectionService cityCollectionService)
        {
            _citiesJsonService = citiesService;
            _cityCollectionService = cityCollectionService;
        }

        [HttpGet]
        public List<string> GetCities(string cityNameFragment)
        {
            return _citiesJsonService.GetCities(cityNameFragment);
        }

        [HttpGet("{main}")]
        public List<string> GetMainCities()
        {
            return _cityCollectionService.GetMainCities();
        }
    }
}
