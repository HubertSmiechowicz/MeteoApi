using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using MeteoApi.Models;
using MeteoApi.Models.Cities;
using MeteoApi.Models.Daily;
using MeteoApi.Models.FiveDays;
using MeteoApi.Models.FiveDays.dtos;
using MeteoApi.Services;
using MeteoApi.Services.Interfaces;
using Moq;

namespace MeteoApi.Tests.Services
{

    public class FiveDaysForecastServiceTests
    {

        private IMapper mapper()
        {
            var productProfile = new MeteoMapperProfile();
            var configuration = new MapperConfiguration(cfg => cfg.AddProfile(productProfile));
            return new Mapper(configuration);
        }

        private FiveDaysForecast GetData()
        {
            CityJson city = new CityJson("Łódź");

            List<Forecast> list = new List<Forecast>();

            // data for sunny image
            var forecast11 = new Forecast(1691498812, new MainDate(293.15, 21, 19, 22, 1020, 81), new Clouds(19), new RainFiveDays(0));
            var forecast12 = new Forecast(1691498812, new MainDate(293.15, 21, 19, 22, 1020, 81), new Clouds(20), new RainFiveDays(0));
            var forecast13 = new Forecast(1691498812, new MainDate(293.15, 21, 19, 22, 1020, 81), new Clouds(12), new RainFiveDays(0));
            var forecast14 = new Forecast(1691498812, new MainDate(293.15, 21, 19, 22, 1020, 81), new Clouds(14), new RainFiveDays(0));
            var forecast15 = new Forecast(1691498812, new MainDate(293.15, 21, 19, 22, 1020, 81), new Clouds(19), new RainFiveDays(0));
            list.Add(forecast11);
            list.Add(forecast12);
            list.Add(forecast13);
            list.Add(forecast14);
            list.Add(forecast15);

            // data for little clouds image
            var forecast21 = new Forecast(1691585212, new MainDate(298.15, 21, 19, 22, 1020, 81), new Clouds(29), new RainFiveDays(0));
            var forecast22 = new Forecast(1691585212, new MainDate(298.15, 21, 19, 22, 1020, 81), new Clouds(22), new RainFiveDays(0));
            var forecast23 = new Forecast(1691585212, new MainDate(298.15, 21, 19, 22, 1020, 81), new Clouds(33), new RainFiveDays(0));
            var forecast24 = new Forecast(1691585212, new MainDate(298.15, 21, 19, 22, 1020, 81), new Clouds(35), new RainFiveDays(0));
            var forecast25 = new Forecast(1691585212, new MainDate(298.15, 21, 19, 22, 1020, 81), new Clouds(33), new RainFiveDays(0));
            list.Add(forecast21);
            list.Add(forecast22);
            list.Add(forecast23);
            list.Add(forecast24);
            list.Add(forecast25);

            // data for more clouds image
            var forecast31 = new Forecast(1691672329, new MainDate(300.15, 21, 19, 22, 1020, 81), new Clouds(41), new RainFiveDays(0));
            var forecast32 = new Forecast(1691672329, new MainDate(300.15, 21, 19, 22, 1020, 81), new Clouds(44), new RainFiveDays(0));
            var forecast33 = new Forecast(1691672329, new MainDate(300.15, 21, 19, 22, 1020, 81), new Clouds(44), new RainFiveDays(0));
            var forecast34 = new Forecast(1691672329, new MainDate(300.15, 21, 19, 22, 1020, 81), new Clouds(51), new RainFiveDays(0));
            var forecast35 = new Forecast(1691672329, new MainDate(300.15, 21, 19, 22, 1020, 81), new Clouds(59), new RainFiveDays(0));
            list.Add(forecast31);
            list.Add(forecast32);
            list.Add(forecast33);
            list.Add(forecast34);
            list.Add(forecast35);

            // data for big clouds image
            var forecast41 = new Forecast(1691758729, new MainDate(303.15, 21, 19, 22, 1020, 81), new Clouds(61), new RainFiveDays(0));
            var forecast42 = new Forecast(1691758729, new MainDate(303.15, 21, 19, 22, 1020, 81), new Clouds(66), new RainFiveDays(0));
            var forecast43 = new Forecast(1691758729, new MainDate(303.15, 21, 19, 22, 1020, 81), new Clouds(71), new RainFiveDays(0));
            var forecast44 = new Forecast(1691758729, new MainDate(303.15, 21, 19, 22, 1020, 81), new Clouds(75), new RainFiveDays(0));
            var forecast45 = new Forecast(1691758729, new MainDate(303.15, 21, 19, 22, 1020, 81), new Clouds(80), new RainFiveDays(0));
            list.Add(forecast41);
            list.Add(forecast42);
            list.Add(forecast43);
            list.Add(forecast44);
            list.Add(forecast45);

            // data for hard clouds image
            var forecast51 = new Forecast(1691845129, new MainDate(306.15, 21, 19, 22, 1020, 81), new Clouds(80), new RainFiveDays(0));
            var forecast52 = new Forecast(1691845129, new MainDate(306.15, 21, 19, 22, 1020, 81), new Clouds(84), new RainFiveDays(0));
            var forecast53 = new Forecast(1691845129, new MainDate(306.15, 21, 19, 22, 1020, 81), new Clouds(89), new RainFiveDays(0));
            var forecast54 = new Forecast(1691845129, new MainDate(306.15, 21, 19, 22, 1020, 81), new Clouds(93), new RainFiveDays(0));
            var forecast55 = new Forecast(1691845129, new MainDate(306.15, 21, 19, 22, 1020, 81), new Clouds(99), new RainFiveDays(0));
            list.Add(forecast51);
            list.Add(forecast52);
            list.Add(forecast53);
            list.Add(forecast54);
            list.Add(forecast55);

            // data for rain image
            var forecast61 = new Forecast(1691931529, new MainDate(308.15, 21, 19, 22, 1020, 81), new Clouds(29), new RainFiveDays(0.9));
            var forecast62 = new Forecast(1691931529, new MainDate(308.15, 21, 19, 22, 1020, 81), new Clouds(22), new RainFiveDays(0.3));
            var forecast63 = new Forecast(1691931529, new MainDate(308.15, 21, 19, 22, 1020, 81), new Clouds(33), new RainFiveDays(0));
            var forecast64 = new Forecast(1691931529, new MainDate(308.15, 21, 19, 22, 1020, 81), new Clouds(35), new RainFiveDays(0));
            var forecast65 = new Forecast(1691931529, new MainDate(308.15, 21, 19, 22, 1020, 81), new Clouds(33), new RainFiveDays(0.1));
            list.Add(forecast61);
            list.Add(forecast62);
            list.Add(forecast63);
            list.Add(forecast64);
            list.Add(forecast65);

            // return list of forecasts

            return new FiveDaysForecast(city, list);
        }

        [Theory]
        [InlineData(0, "src/assets/sunny.png")]
        [InlineData(1, "src/assets/littleClouds.png")]
        [InlineData(2, "src/assets/moreClouds.png")]
        [InlineData(3, "src/assets/bigClouds.png")]
        [InlineData(4, "src/assets/hardClouds.png")]
        [InlineData(5, "src/assets/rain.png")]
        public void GetFiveDaysForecast_ForGivenData_ReturnsCorrectImage(int index, string image)
        {
            // arrange

            var connectApiMock = new Mock<IWeatherApiConnect>();
            connectApiMock.Setup(m => m.GetForecastFromApi<FiveDaysForecast>(It.IsAny<string>(), It.IsAny<string>()))
                .Returns(GetData());

            FiveDaysForecastService fiveDaysForecastService = new FiveDaysForecastService(connectApiMock.Object, mapper());

            // act

            var result = fiveDaysForecastService.GetFiveDaysForecast("Łódź").forecastDtos[index].image;

            // assert

            Assert.Equal(image, result);
        }

        [Theory]
        [InlineData(0, 20)]
        [InlineData(1, 25)]
        [InlineData(2, 27)]
        [InlineData(3, 30)]
        [InlineData(4, 33)]
        [InlineData(5, 35)]
        public void GetFiveDaysForecast_ForGivenData_ReturnsCorrectTemperatures(int index, double temperatures) 
        {
            var connectApiMock = new Mock<IWeatherApiConnect>();
            connectApiMock.Setup(m => m.GetForecastFromApi<FiveDaysForecast>(It.IsAny<string>(), It.IsAny<string>()))
                .Returns(GetData());

            FiveDaysForecastService fiveDaysForecastService = new FiveDaysForecastService(connectApiMock.Object, mapper());

            // act

            var result = fiveDaysForecastService.GetFiveDaysForecast("Łódź").forecastDtos[index].temp;

            // assert

            Assert.Equal(temperatures, result);
        }

        [Fact]
        public void GetFiveDaysForecast_ForGivenData_ReturnsCorrectCityName()
        {
            // arrange

            var connectApiMock = new Mock<IWeatherApiConnect>();
            connectApiMock.Setup(m => m.GetForecastFromApi<FiveDaysForecast>(It.IsAny<string>(), It.IsAny<string>()))
                .Returns(GetData());

            FiveDaysForecastService fiveDaysForecastService = new FiveDaysForecastService(connectApiMock.Object, mapper());

            // act

            var result = fiveDaysForecastService.GetFiveDaysForecast("Łódź").name;

            // assert

            Assert.Equal("Łódź", result);
        }

        [Fact]
        public void GetFiveDaysForecast_ForGivenData_HaveCorrectSizeOfForecasts()
        {
            // arrange

            var connectApiMock = new Mock<IWeatherApiConnect>();
            connectApiMock.Setup(m => m.GetForecastFromApi<FiveDaysForecast>(It.IsAny<string>(), It.IsAny<string>()))
                .Returns(GetData());

            FiveDaysForecastService fiveDaysForecastService = new FiveDaysForecastService(connectApiMock.Object, mapper());

            // act

            var result = fiveDaysForecastService.GetFiveDaysForecast("Łódź").forecastDtos.Count;

            // assert

            Assert.Equal(6, result);
        }
    }
}
