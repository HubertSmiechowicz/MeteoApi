using MeteoApi.Models;
using MeteoApi.Models.dtos;

namespace MeteoApi.Services
{
    public class PresentDayForecastService : IPresentDayForecastService
    {

        private IWeatherApiConnect _connect;
        private readonly string specURI = "weather?";

        public PresentDayForecastService(IWeatherApiConnect connect)
        {
            _connect = connect;
        }

        public PresentDayForecastDto GetForecastForCity(string cityName)
        {
            var presentDayForecastFromApi = _connect.GetForecastFromApi<PresentDayForecast>(specURI, cityName);

            var main = presentDayForecastFromApi.main;

            double tempRounded;
            main.CalculateTemp(presentDayForecastFromApi.main.temp, out tempRounded);

            double feelsRounded;
            main.CalculateTemp(presentDayForecastFromApi.main.feels_like, out feelsRounded);

            double tempMaxRounded;
            main.CalculateTemp(presentDayForecastFromApi.main.temp_max, out tempMaxRounded);

            var rain = new Rain();

            return new PresentDayForecastDto(presentDayForecastFromApi.name, presentDayForecastFromApi.weather[0].description, tempRounded.ToString(), feelsRounded.ToString(), tempMaxRounded.ToString(), presentDayForecastFromApi.main.pressure, presentDayForecastFromApi.main.humidity, presentDayForecastFromApi.wind.speed, rain.getRain(rain), presentDayForecastFromApi.clouds.getCloudImage(rain.getRain(rain)), presentDayForecastFromApi.clouds.all);

        }


        public List<PresentDayForecastSimpleDto> GetSimpleForecastForListOfCities(List<string> cityNames)
        {
            List<PresentDayForecastSimpleDto> simpleDtos = new List<PresentDayForecastSimpleDto>();
            foreach (string cityName in cityNames)
            {
                var presentDayForecastFromApi = _connect.GetForecastFromApi<PresentDayForecast>(specURI, cityName);

                double tempRounded;
                presentDayForecastFromApi.main.CalculateTemp(presentDayForecastFromApi.main.temp, out tempRounded);

                var rain = new Rain();

                var simpleDto = new PresentDayForecastSimpleDto(presentDayForecastFromApi.name, tempRounded.ToString(), presentDayForecastFromApi.clouds.getCloudImage(rain.getRain(rain)));
                simpleDtos.Add(simpleDto);
            }
            return simpleDtos;
        }
    }
}
