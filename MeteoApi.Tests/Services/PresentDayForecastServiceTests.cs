using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MeteoApi.Models;
using MeteoApi.Models.Daily;
using MeteoApi.Services;
using MeteoApi.Services.Interfaces;
using Moq;

namespace MeteoApi.Tests.Services
{
    public class PresentDayForecastServiceTests

    {

        private PresentDayForecast presentDayForecast(string cityName, string temp, string all, string rain)
        {
            return new PresentDayForecast(cityName, new List<Weather>() { new Weather("Lekkie zachmurzenie") }, new MainDate(temp, "295.15", "292.15", "296.15", "1014", "0.5"), new Wind("10"), new Clouds(all), new Rain(rain));
        }

        [Theory]
        [InlineData("Łódź")]
        [InlineData("Warszawa")]
        [InlineData("Kraków")]
        [InlineData("Częstochowa")]
        [InlineData("Radom")]
        public void GetForecastForCity_ForGivenCityName_ReturnsCorrectCityName(string cityName)
        {
            // arrange

            var apiConnectMock = new Mock<IWeatherApiConnect>();
            apiConnectMock.Setup(m => m.GetForecastFromApi<PresentDayForecast>(It.IsAny<string>(), It.IsAny<string>()))
                .Returns(presentDayForecast(cityName, "294.15", "21", "0"));

            var presentDayForecastService = new PresentDayForecastService(apiConnectMock.Object);

            // act

            var cityNameResult = presentDayForecastService.GetForecastForCity(cityName).name;

            // assert

            Assert.Equal(cityName, cityNameResult);
        }

        [Theory]
        [InlineData("294.15", "21")]
        [InlineData("295.15", "22")]
        [InlineData("300.15", "27")]
        [InlineData("300.85", "27,7")]
        [InlineData("284.45", "11,3")]
        public void GetForecastForCity_ForGivenTemperatureInKelvin_ReturnsCorrectTemperatureInCelsius(string kelvin, string celsius)
        {
            // arrange

            var apiConnectMock = new Mock<IWeatherApiConnect>();
            apiConnectMock.Setup(m => m.GetForecastFromApi<PresentDayForecast>(It.IsAny<string>(), It.IsAny<string>()))
                .Returns(presentDayForecast("Łódź", kelvin, "21", "0"));

            var presentDayForecastService = new PresentDayForecastService(apiConnectMock.Object);

            // act

            var temperatureInCelcius = presentDayForecastService.GetForecastForCity("Łódź").temp;

            // assert

            Assert.Equal(celsius, temperatureInCelcius);
        }

        [Theory]
        [InlineData("15", "0", "src/assets/sunny.png")]
        [InlineData("34", "0", "src/assets/littleClouds.png")]
        [InlineData("51", "0", "src/assets/moreClouds.png")]
        [InlineData("69", "0", "src/assets/bigClouds.png")]
        [InlineData("99", "0", "src/assets/hardClouds.png")]
        [InlineData("40", "0.3", "src/assets/rain.png")]
        public void GetForecastForCity_ForGivenCloudsAndRain_ReturnsCorrectImage(string all, string rain, string image)
        {
            // arrange

            var apiConnectMock = new Mock<IWeatherApiConnect>();
            apiConnectMock.Setup(m => m.GetForecastFromApi<PresentDayForecast>(It.IsAny<string>(), It.IsAny<string>()))
                .Returns(presentDayForecast("Łódź", "294.15", all, rain));

            var presentDayForecastService = new PresentDayForecastService(apiConnectMock.Object);

            // act

            var imageResult = presentDayForecastService.GetForecastForCity("Łódź").image;

            // assert

            Assert.Equal(image, imageResult);
        }

        [Theory]
        [InlineData("Łódź")]
        [InlineData("Warszawa")]
        [InlineData("Kraków")]
        [InlineData("Częstochowa")]
        [InlineData("Radom")]
        public void GetSimpleForecastForListOfCities_ForGivenCityName_ReturnsCorrectCityName(string cityName)
        {
            // arrange

            var apiConnectMock = new Mock<IWeatherApiConnect>();
            apiConnectMock.Setup(m => m.GetForecastFromApi<PresentDayForecast>(It.IsAny<string>(), It.IsAny<string>()))
                .Returns(presentDayForecast(cityName, "294.15", "21", "0"));

            var presentDayForecastService = new PresentDayForecastService(apiConnectMock.Object);

            // act

            var cityNameResult = presentDayForecastService.GetSimpleForecastForListOfCities(new List<string>() { cityName })[0].name;

            // assert

            Assert.Equal(cityName, cityNameResult);
        }

        [Theory]
        [InlineData("294.15", "21")]
        [InlineData("295.15", "22")]
        [InlineData("300.15", "27")]
        [InlineData("300.85", "27,7")]
        [InlineData("284.45", "11,3")]
        public void GetSimpleForecastForListOfCities_ForGivenTemperatureInKelvin_ReturnsCorrectTemperatureInCelsius(string kelvin, string celsius)
        {
            // arrange

            var apiConnectMock = new Mock<IWeatherApiConnect>();
            apiConnectMock.Setup(m => m.GetForecastFromApi<PresentDayForecast>(It.IsAny<string>(), It.IsAny<string>()))
                .Returns(presentDayForecast("Łódź", kelvin, "21", "0"));

            var presentDayForecastService = new PresentDayForecastService(apiConnectMock.Object);

            // act

            var temperatureInCelcius = presentDayForecastService.GetSimpleForecastForListOfCities(new List<string>() { "Łódź" })[0].temp;

            // assert

            Assert.Equal(celsius, temperatureInCelcius);
        }

        [Theory]
        [InlineData("15", "0", "src/assets/sunny.png")]
        [InlineData("34", "0", "src/assets/littleClouds.png")]
        [InlineData("51", "0", "src/assets/moreClouds.png")]
        [InlineData("69", "0", "src/assets/bigClouds.png")]
        [InlineData("99", "0", "src/assets/hardClouds.png")]
        [InlineData("40", "0.3", "src/assets/rain.png")]
        public void GetSimpleForecastForListOfCities_ForGivenCloudsAndRain_ReturnsCorrectImage(string all, string rain, string image)
        {
            // arrange

            var apiConnectMock = new Mock<IWeatherApiConnect>();
            apiConnectMock.Setup(m => m.GetForecastFromApi<PresentDayForecast>(It.IsAny<string>(), It.IsAny<string>()))
                .Returns(presentDayForecast("Łódź", "294.15", all, rain));

            var presentDayForecastService = new PresentDayForecastService(apiConnectMock.Object);

            // act

            var imageResult = presentDayForecastService.GetSimpleForecastForListOfCities(new List<string>() { "Łódź" })[0].image;

            // assert

            Assert.Equal(image, imageResult);
        }
    }
}
