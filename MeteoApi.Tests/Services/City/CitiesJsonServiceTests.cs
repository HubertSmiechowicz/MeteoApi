using MeteoApi.Models.Cities;
using MeteoApi.Services.City;
using MeteoApi.Services.Interfaces;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeteoApi.Tests.Services.City
{
    public class CitiesJsonServiceTests
    {

        private List<CityJson> GetData()
        {
            List<CityJson> cities = new List<CityJson>();
            CityJson city1 = new CityJson("Józefów");
            CityJson city2 = new CityJson("Grunwald");
            CityJson city3 = new CityJson("Komańcza");
            CityJson city4 = new CityJson("Łaziska");
            CityJson city5 = new CityJson("Karpacz");
            CityJson city6 = new CityJson("Ostrołęka");
            CityJson city7 = new CityJson("Lubin");
            CityJson city8 = new CityJson("Kaliska");
            CityJson city9 = new CityJson("Częstochowa");
            CityJson city10 = new CityJson("Koszalin");
            cities.Add(city1);
            cities.Add(city2);
            cities.Add(city3);
            cities.Add(city4);
            cities.Add(city5);
            cities.Add(city6);
            cities.Add(city7);
            cities.Add(city8);
            cities.Add(city9);
            cities.Add(city10);
            return cities;
        }

        [Fact]
        public void GetCities_WithCityNameFragmentReturn_ShouldReturnCorrectLenghtListOfCitiesNames()
        {
            // arrange

            var filesOperationServiceMock = new Mock<IFilesOperationService>();
            filesOperationServiceMock.Setup(m => m.ReadJsonFile<List<CityJson>>(It.IsAny<string>()))
                .Returns(GetData());

            CitiesJsonService citiesJsonService = new CitiesJsonService(filesOperationServiceMock.Object);

            // act

            var citiesListLength = citiesJsonService.GetCities("k").Count();

            // assert

            Assert.True(citiesListLength == 6);
        }

        [Fact]
        public void GetCities_WithFullCityName_ShouldReturnOneRecord()
        {
            // arrange

            var filesOperationServiceMock = new Mock<IFilesOperationService>();
            filesOperationServiceMock.Setup(m => m.ReadJsonFile<List<CityJson>>(It.IsAny<string>()))
                .Returns(GetData());

            CitiesJsonService citiesJsonService = new CitiesJsonService(filesOperationServiceMock.Object);

            // act

            var citiesListLength = citiesJsonService.GetCities("koszalin").Count();

            // assert

            Assert.True(citiesListLength == 1);
        }

        [Fact]
        public void GetCities_WithFullCityName_ReturnsCorrectCityName()
        {
            // arrange

            var filesOperationServiceMock = new Mock<IFilesOperationService>();
            filesOperationServiceMock.Setup(m => m.ReadJsonFile<List<CityJson>>(It.IsAny<string>()))
                .Returns(GetData());

            CitiesJsonService citiesJsonService = new CitiesJsonService(filesOperationServiceMock.Object);

            // act

            var cityName = citiesJsonService.GetCities("koszalin")[0];

            // assert

            Assert.Equal("Koszalin", cityName);
        }
    }
}
