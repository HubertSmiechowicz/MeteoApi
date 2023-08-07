using MeteoApi.Models.FiveDays.dtos;

namespace MeteoApi.Services.Interfaces
{
    public interface IFiveDaysForecastService
    {
        FiveDaysForecastDto GetFiveDaysForecast(string name);
    }
}