using MeteoApi.Models.FiveDays.dtos;

namespace MeteoApi.Services
{
    public interface IFiveDaysForecastService
    {
        FiveDaysForecastDto GetFiveDaysForecast(string name);
    }
}