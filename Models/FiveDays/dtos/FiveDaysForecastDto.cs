namespace MeteoApi.Models.FiveDays.dtos
{
    public class FiveDaysForecastDto
    {
        public string name { get; private set; }

        public List<ForecastDto> forecastDtos { get; private set; }

        public FiveDaysForecastDto(string name, List<ForecastDto> forecastDtos) 
        {
            this.name = name;
            this.forecastDtos = forecastDtos;
        }
    }
}
