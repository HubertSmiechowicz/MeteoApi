using MeteoApi.Models;

namespace MeteoApi.Services.Interfaces
{
    public interface IWeatherApiConnect
    {
        T GetForecastFromApi<T>(string specURI, string cityName);
    }
}