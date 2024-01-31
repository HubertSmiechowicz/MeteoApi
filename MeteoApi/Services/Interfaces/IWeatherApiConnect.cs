using MeteoApi.Models;

namespace MeteoApi.Services.Interfaces
{
    public interface IWeatherApiConnect
    {
        T GetForecastFromApi<T>(string specURI, string cityName);
        T GetForecastFromApi<T>(string specURI, double lat, double lon);
        T GetGeocoding<T>(string cityName);
    }
}