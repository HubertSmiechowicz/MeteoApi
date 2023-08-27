using AutoMapper;
using MeteoApi.Models.Daily;
using MeteoApi.Models.Daily.dtos;
using MeteoApi.Services.Interfaces;

namespace MeteoApi.Services
{
    public class PresentDayForecastService : IPresentDayForecastService
    {

        private readonly IWeatherApiConnect _connect;
        private readonly IMapper _mapper;
        private readonly string specURI = "weather?";

        public PresentDayForecastService(IWeatherApiConnect connect, IMapper mapper)
        {
            _connect = connect;
            _mapper = mapper;
        }

        public PresentDayForecastDto GetForecastForCity(string cityName)
        {
            var presentDayForecastFromApi = _connect.GetForecastFromApi<PresentDayForecast>(specURI, cityName);

            var presentDayForecastDto = _mapper.Map<PresentDayForecastDto>(presentDayForecastFromApi);

            return presentDayForecastDto;
        }


        public List<PresentDayForecastSimpleDto> GetSimpleForecastForListOfCities(List<string> cityNames)
        {
            List<PresentDayForecastSimpleDto> simpleDtos = new List<PresentDayForecastSimpleDto>();
            foreach (string cityName in cityNames)
            {
                var presentDayForecastFromApi = _connect.GetForecastFromApi<PresentDayForecast>(specURI, cityName);

                var simpleDto = _mapper.Map<PresentDayForecastSimpleDto>(presentDayForecastFromApi);
                simpleDtos.Add(simpleDto);
            }
            return simpleDtos;
        }
    }
}
