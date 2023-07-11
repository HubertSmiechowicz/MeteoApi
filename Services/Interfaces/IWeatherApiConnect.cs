using MeteoApi.Models;

namespace MeteoApi.Services
{
    public interface IWeatherApiConnect
    {
        PresentDayForecast GetPresentDayForecastFromApi(string specURI, string cityName);
    }
}