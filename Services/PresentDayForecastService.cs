using MeteoApi.Models;
using MeteoApi.Models.dtos;
using System.Globalization;

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
            PresentDayForecast presentDayForecastFromApi = _connect.GetPresentDayForecastFromApi(specURI, cityName);

            double tempRounded;
            CalculateTemp(presentDayForecastFromApi.main.temp, out tempRounded);

            double feelsRounded;
            CalculateTemp(presentDayForecastFromApi.main.feels_like, out feelsRounded);

            double tempMaxRounded;
            CalculateTemp(presentDayForecastFromApi.main.temp_max, out tempMaxRounded);

            string rain = getRain(presentDayForecastFromApi);

            return mapResponsePresentDayForecast(presentDayForecastFromApi, tempRounded, feelsRounded, tempMaxRounded, rain);

        }


        public List<PresentDayForecastSimpleDto> GetSimpleForecastForListOfCities(List<string> cityNames)
        {
            List<PresentDayForecastSimpleDto> simpleDtos = new List<PresentDayForecastSimpleDto>();
            foreach (string cityName in cityNames) 
            {
                var presentDayForecastFromApi = _connect.GetPresentDayForecastFromApi(specURI, cityName);

                double tempRounded;
                CalculateTemp(presentDayForecastFromApi.main.temp, out tempRounded);

                string rain = getRain(presentDayForecastFromApi);

                var simpleDto = new PresentDayForecastSimpleDto(presentDayForecastFromApi.name, tempRounded.ToString(), getCloudImage(presentDayForecastFromApi.clouds.all, rain));
                simpleDtos.Add(simpleDto);
            }
            return simpleDtos;
        }
        private static string getRain(PresentDayForecast presentDayForecastFromApi)
        {
            string rain;
            if (presentDayForecastFromApi.rain != null)
            {
                rain = presentDayForecastFromApi.rain.oneh;
            }
            else
            {
                rain = "0";
            }

            return rain;
        }

        private void CalculateTemp(string tempApi, out double tempRounded)
        {
            double temp;
            double.TryParse(tempApi, System.Globalization.CultureInfo.InvariantCulture, out temp);
            temp -= 273.15;
            tempRounded = Math.Round(temp, 1);
        }

        private PresentDayForecastDto mapResponsePresentDayForecast(PresentDayForecast presentDayForecastFromApi, double tempRounded, double feelsRounded, double tempMaxRounded, string rain)
        {
            var mainDate = new MainDate(tempRounded.ToString(), feelsRounded.ToString(), presentDayForecastFromApi.main.pressure, presentDayForecastFromApi.main.humidity);
            var weatherOne = new Weather(presentDayForecastFromApi.weather[0].description);
            var weather = new List<Weather>();
            weather.Add(weatherOne);
            var wind = new Wind(presentDayForecastFromApi.wind.speed);
            var clouds = new Clouds(presentDayForecastFromApi.clouds.all);
            var presentDayForecastDto = new PresentDayForecastDto(presentDayForecastFromApi.name, presentDayForecastFromApi.weather[0].description, tempRounded.ToString(), feelsRounded.ToString(), tempMaxRounded.ToString(), presentDayForecastFromApi.main.pressure, presentDayForecastFromApi.main.humidity, presentDayForecastFromApi.wind.speed, rain, getCloudImage(presentDayForecastFromApi.clouds.all, rain), presentDayForecastFromApi.clouds.all);
            
            return presentDayForecastDto;
        }

        private string getCloudImage(string all, string rainStr)
        {
            int cloudPercent;
            int.TryParse(all, out cloudPercent);

            double rain;
            double.TryParse(rainStr, System.Globalization.CultureInfo.InvariantCulture, out rain);

            if (rain > 0)
            {
                return "src/assets/rain.png";
            }
            if (cloudPercent >= 0 && cloudPercent < 20 && rain == 0)
            {
                return "src/assets/sunny.png";
            }
            else if (cloudPercent >= 20 && cloudPercent < 40 && rain == 0)
            {
                return "src/assets/littleClouds.png";
            }
            else if (cloudPercent >= 40 && cloudPercent < 60 && rain == 0)
            {
                return "src/assets/moreClouds.png";
            }
            else if (cloudPercent >= 60 && cloudPercent < 80 && rain == 0)
            {
                return "src/assets/bigClouds.png";
            }
            else if (cloudPercent >= 80 && cloudPercent <= 100 && rain == 0)
            {
                return "src/assets/hardClouds.png";
            }
            else
            {
                return "";
            }
        }

    }
}
