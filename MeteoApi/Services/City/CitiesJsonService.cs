using MeteoApi.Models;
using System.Linq;
using System.Globalization;
using System.Text;
using MeteoApi.Services.Interfaces;
using MeteoApi.Models.Cities;

namespace MeteoApi.Services.City
{
    public class CitiesJsonService : ICitiesJsonService
    {

        private IFilesOperationService _filesOperationService;

        public CitiesJsonService(IFilesOperationService filesOperationService)
        {
            _filesOperationService = filesOperationService;
        }


        public List<string> GetCities(string cityNameFragment)
        {
            var listCities = _filesOperationService.ReadJsonFile<List<CityJson>>("D:\\Dokumenty\\source\\repos\\MeteoApplication\\MeteoApi\\files\\city.list.json");
            var cityNames = listCities.Where(city => city.Name.Contains(cityNameFragment, StringComparison.OrdinalIgnoreCase)).Select(city => city.Name).ToList();
            return cityNames;
        }
    }
}
