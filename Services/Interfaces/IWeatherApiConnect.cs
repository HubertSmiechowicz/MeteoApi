using MeteoApi.Models;

namespace MeteoApi.Services
{
    public interface IWeatherApiConnect
    {
        PresentDayForecast GetDataFromApi(string specURI, string cityName);
    }
}