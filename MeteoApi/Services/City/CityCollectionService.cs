using MeteoApi.Models.Cities;
using MeteoApi.Models.FiveDays;
using MeteoApi.Services.Interfaces;

namespace MeteoApi.Services.City
{
    public class CityCollectionService : ICityCollectionService
    {

        private CityCollection cityCollection = new CityCollection();

        public List<string> GetMainCities()
        {
            return cityCollection.GetMainCities();
        }
    }
}
