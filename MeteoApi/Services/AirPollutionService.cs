using AutoMapper;
using MeteoApi.Models.Air;
using MeteoApi.Models.Air.dtos;
using MeteoApi.Services.Interfaces;

namespace MeteoApi.Services
{
    public class AirPollutionService : IAirPollutionService
    {
        private readonly IWeatherApiConnect _weatherApiConnect;
        private readonly IMapper _mapper;
        private readonly string specURI = "air_pollution?";

        public AirPollutionService(IWeatherApiConnect weatherApiConnect, IMapper mapper) 
        {
            _weatherApiConnect = weatherApiConnect;
            _mapper = mapper;
        }

        public AirPollutionDto GetAirPollution(string cityName) 
        {
            var geocoding = _weatherApiConnect.GetGeocoding<List<Geocoding>>(cityName);

            var airPollutionFromApi = _weatherApiConnect.GetForecastFromApi<AirPollutionList>(specURI, geocoding[0].lat, geocoding[0].lon);

            var airPollutionDto = _mapper.Map<AirPollutionDto>(airPollutionFromApi);

            return airPollutionDto;
        }
    }
}
