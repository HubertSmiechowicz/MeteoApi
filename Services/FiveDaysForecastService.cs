using MeteoApi.Models.FiveDays;
using MeteoApi.Models.FiveDays.dtos;
using MeteoApi.Models.monthly;

namespace MeteoApi.Services
{
    public class FiveDaysForecastService : IFiveDaysForecastService
    {
        private IWeatherApiConnect _connect;
        private readonly string specURI = "forecast?";

        public FiveDaysForecastService(IWeatherApiConnect connect)
        {
            _connect = connect;
        }

        public FiveDaysForecastDto GetFiveDaysForecast(string name)
        {
            var forecastFromApi = _connect.GetForecastFromApi<FiveDaysForecast>(specURI, name);

            var forecastDtos = new List<ForecastDto>();

            foreach (Forecast forecast in forecastFromApi.list) 
            {
                var rain = new RainFiveDays();

                double tempRounded;
                forecast.main.CalculateTemp(forecast.main.temp, out tempRounded);

                double maxTempRounded;
                forecast.main.CalculateTemp(forecast.main.temp_max, out maxTempRounded);

                var forecastDto = new ForecastDto(forecast.dt.ToString(), tempRounded.ToString(), maxTempRounded.ToString(), forecast.clouds.getCloudImage(rain.getRain(forecast.rain)));
                forecastDtos.Add(forecastDto);
            }

            return new FiveDaysForecastDto(forecastFromApi.city.name, forecastDtos);
        }
    }
}
