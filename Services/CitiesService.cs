using MeteoApi.Models;
using System.Linq;
using System.Globalization;
using System.Text;

namespace MeteoApi.Services
{
    public class CitiesService : ICitiesService
    {

        private IFilesOperationService _filesOperationService;

        CItyNamesRepo cityNamesRepo = new CItyNamesRepo();

        public CitiesService(IFilesOperationService filesOperationService) 
        {
            _filesOperationService = filesOperationService;
        }


        public List<string> GetCities(string cityNameFragment)
        {
            var listCities = _filesOperationService.ReadJsonFile<List<CityApi>>("D:\\Dokumenty\\source\\repos\\MeteoApi\\files\\city.list.json");
            var cityNames = listCities.Where(city => city.Name.Contains(cityNameFragment, StringComparison.OrdinalIgnoreCase)).Select(city => city.Name).ToList();
            return cityNames;
        }

        public List<string> GetMainCities() 
        {
            return cityNamesRepo.GetMainCities();
        }
    }
}
