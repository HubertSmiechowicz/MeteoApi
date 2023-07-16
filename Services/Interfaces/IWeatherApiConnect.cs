using MeteoApi.Models;

namespace MeteoApi.Services
{
    public interface IWeatherApiConnect
    {
        T GetForecastFromApi<T>(string specURI, string cityName);
    }
}