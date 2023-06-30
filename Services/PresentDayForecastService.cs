using MeteoApi.Models;

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

        public PresentDayForecast GetForecastForCity(string cityName)
        {
            return _connect.GetDataFromApi(specURI, cityName);
        }

    }
}
