using AutoMapper;
using MeteoApi.Models.Daily;
using MeteoApi.Models.Daily.dtos;
using MeteoApi.Models.FiveDays.dtos;
using MeteoApi.Models.FiveDays;
using MeteoApi.Models.Air.dtos;
using MeteoApi.Models.Air;


namespace MeteoApi.Models
{
    public class MeteoMapperProfile : Profile
    {
        private ForecastDto forecastDto = new ForecastDto();

        public MeteoMapperProfile()
        {
            CreateMap<PresentDayForecast, PresentDayForecastDto>()
                .ForMember(m => m.description, c => c.MapFrom(s => s.weather[0].description))
                .ForMember(m => m.temp, c => c.MapFrom(s => s.main.CalculateTemp(s.main.temp)))
                .ForMember(m => m.feelsLike, c => c.MapFrom(s => s.main.CalculateTemp(s.main.feels_like)))
                .ForMember(m => m.tempMax, c => c.MapFrom(s => s.main.CalculateTemp(s.main.temp_max)))
                .ForMember(m => m.pressure, c => c.MapFrom(s => s.main.pressure))
                .ForMember(m => m.humidity, c => c.MapFrom(s => s.main.humidity))
                .ForMember(m => m.windSpeed, c => c.MapFrom(s => s.wind.speed))
                .ForMember(m => m.image, c => c.MapFrom(s => s.clouds.GetCloudImage(s.rain)))
                .ForMember(m => m.all, c => c.MapFrom(s => s.clouds.all));

            CreateMap<PresentDayForecast, PresentDayForecastSimpleDto>()
                .ForMember(m => m.temp, c => c.MapFrom(s => s.main.CalculateTemp(s.main.temp)))
                .ForMember(m => m.image, c => c.MapFrom(s => s.clouds.GetCloudImage(s.rain)));

            CreateMap<Forecast, ForecastDto>()
                .ForMember(m => m.dt, c => c.MapFrom(s => forecastDto.fromUnixToDateTime(s.dt)))
                .ForMember(m => m.temp, c => c.MapFrom(s => s.main.CalculateTemp(s.main.temp)))
                .ForMember(m => m.cloud, c => c.MapFrom(s => s.clouds.all))
                .ForMember(m => m.rain, c => c.MapFrom(s => s.rain.rain))
                .ForMember(m => m.image, c => c.MapFrom(s => s.clouds.GetCloudImage(s.rain)));

            CreateMap<AirPollutionList, AirPollutionDto>()
                .ForMember(m => m.descriptionPollution, c => c.MapFrom(s => s.List[0].Main.GetPollutionDescription(s.List[0].Main.Aqi)))
                .ForMember(m => m.imagePollution, c => c.MapFrom(s => s.List[0].Main.GetPollutionImage(s.List[0].Main.Aqi)))
                .ForMember(m => m.Co, c => c.MapFrom(s => s.List[0].Components.Co))
                .ForMember(m => m.No, c => c.MapFrom(s => s.List[0].Components.No))
                .ForMember(m => m.No2, c => c.MapFrom(s => s.List[0].Components.No2))
                .ForMember(m => m.O3, c => c.MapFrom(s => s.List[0].Components.O3))
                .ForMember(m => m.So2, c => c.MapFrom(s => s.List[0].Components.So2))
                .ForMember(m => m.Pm2_5, c => c.MapFrom(s => s.List[0].Components.Pm2_5))
                .ForMember(m => m.Nh3, c => c.MapFrom(s => s.List[0].Components.Nh3));
        }
    }
}
