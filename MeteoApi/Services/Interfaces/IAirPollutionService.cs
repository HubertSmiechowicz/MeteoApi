using MeteoApi.Models.Air.dtos;

namespace MeteoApi.Services.Interfaces
{
    public interface IAirPollutionService
    {
        AirPollutionDto GetAirPollution(string cityName);
    }
}
