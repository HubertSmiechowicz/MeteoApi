using MeteoApi.Models;

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


        public List<string> GetCities()
        {
            var listCities = _filesOperationService.ReadJsonFile<List<CityApi>>("C:\\Users\\jolan\\Hubert\\source\\MeteoApi\\files\\city.list.json");
            var cityNames = new List<string>();
            foreach (var city in listCities) 
            {
                string cityName = city.Name;
                cityNames.Add(cityName);
            }

            return cityNames;
        }

        public List<string> GetMainCities() 
        {
            return cityNamesRepo.GetMainCities();
        }
    }
}
