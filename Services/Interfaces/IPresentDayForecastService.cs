using MeteoApi.Models;

namespace MeteoApi.Services
{
    public interface IPresentDayForecastService
    {
        PresentDayForecast GetForecastForCity(string cityName);
    }
}