using MeteoApi.Models;

namespace MeteoApi.Services
{
    public class CitiesService : ICitiesService
    {

        Cities cities = new Cities();

        public List<string> GetCities()
        {
            return cities.GetCities();
        }

        public List<string> GetMainCities() 
        {
            return cities.GetMainCities();
        }
    }
}
