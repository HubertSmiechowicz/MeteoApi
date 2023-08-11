using MeteoApi.Models.Daily.dtos;

namespace MeteoApi.Services.Interfaces
{
    public interface IPresentDayForecastService
    {
        PresentDayForecastDto GetForecastForCity(string cityName);

        List<PresentDayForecastSimpleDto> GetSimpleForecastForListOfCities(List<string> cityNames);
    }
}