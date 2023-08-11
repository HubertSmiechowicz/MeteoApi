using MeteoApi.Services.City;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeteoApi.Tests.Services.City
{
    public class CityCollectionServiceTests
    {
        [Fact]
        public void GetMainCities_ShouldReturnCorrectLenghtListOfCitiesNames()
        {

            // arrange

            CityCollectionService cityCollectionService = new CityCollectionService();

            // act

            var cityCollectionLenght = cityCollectionService.GetMainCities().Count;

            // assert
            Assert.True(cityCollectionLenght == 8);
        }

        [Theory]
        [InlineData(0, "Warszawa")]
        [InlineData(7, "Katowice")]
        public void GetMainCities_ShouldReturnCorrectFirstAndLastCityName(int index, string cityName)
        {
            // arrange 

            CityCollectionService cityCollectionService = new CityCollectionService();

            // act

            var cityNameResult = cityCollectionService.GetMainCities()[index];

            // assert

            Assert.Equal(cityName, cityNameResult);
        }

        [Fact]
        public void GetMainCities_ShouldReturnNotEmptyList() 
        {
            // arrange

            CityCollectionService cityCollectionService = new CityCollectionService();

            // act

            var cityCollectionLenght = cityCollectionService.GetMainCities().Count;

            // assert

            Assert.True(cityCollectionLenght > 0);
        }
    }
}
