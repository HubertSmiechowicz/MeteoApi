using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
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

            string filePath = Path.Combine(Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.FullName, "files", "city.list.test.json");

            FilesOperationService service = new FilesOperationService();
            service.FilePath = filePath;

            // act

            var listCitiesLength = service.ReadJsonFile<List<CityJson>>().Count;

            // assert

            Assert.True(listCitiesLength == 23);
        }

        [Theory]
        [InlineData(0, "Świętochłowice")]
        [InlineData(22, "Koszalin")]
        public void ReadJsonFile_WithJsonFile_ShouldReturnCorrectFirstAndLastCityName(int index, string cityName)
        {

            // arrange

            string filePath = Path.Combine(Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.FullName, "files", "city.list.test.json");

            FilesOperationService service = new FilesOperationService();
            service.FilePath = filePath;

            // act

            var cityNameResult = service.ReadJsonFile<List<CityJson>>()[index].Name;

            // assert

            Assert.Equal(cityName, cityNameResult);
        }
    }
}
