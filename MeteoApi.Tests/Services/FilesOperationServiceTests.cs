using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MeteoApi.Models.Cities;
using MeteoApi.Services;

namespace MeteoApi.Tests.Services
{
    public class FilesOperationServiceTests
    {

        [Fact]
        public void ReadJsonFile_WithJsonFile_ShouldReturnCorrectLenghtListOfCities()
        {

            // arrange

            FilesOperationService service = new FilesOperationService();

            // act

            var listCitiesLength = service.ReadJsonFile<List<CityJson>>("D:\\Dokumenty\\source\\repos\\MeteoApplication\\MeteoApi.Tests\\files\\city.list.test.json").Count;

            // assert

            Assert.True(listCitiesLength == 23);
        }

        [Theory]
        [InlineData(0, "Świętochłowice")]
        [InlineData(22, "Koszalin")]
        public void ReadJsonFile_WithJsonFile_ShouldReturnCorrectFirstAndLastCityName(int index, string cityName)
        {

            // arrange

            FilesOperationService service = new FilesOperationService();

            // act

            var cityNameResult = service.ReadJsonFile<List<CityJson>>("D:\\Dokumenty\\source\\repos\\MeteoApplication\\MeteoApi.Tests\\files\\city.list.test.json")[index].Name;

            // assert

            Assert.Equal(cityName, cityNameResult);
        }
    }
}
