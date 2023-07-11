using MeteoApi.Models.dtos;

namespace MeteoApi.Services
{
    public interface IPresentDayForecastService
    {
        PresentDayForecastDto GetForecastForCity(string cityName);

        List<PresentDayForecastSimpleDto> GetSimpleForecastForListOfCities(List<string> cityNames);
    }
}