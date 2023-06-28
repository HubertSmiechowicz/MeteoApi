namespace MeteoApi.Services
{
    public interface IPresentDayForecastService
    {
        string GetForecastForCity(string cityName);
    }
}