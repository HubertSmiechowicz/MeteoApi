using AutoMapper;
using MeteoApi.Models;
using MeteoApi.Models.FiveDays;
using MeteoApi.Models.FiveDays.dtos;
using MeteoApi.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing.Template;
using System;
using System.Linq;

namespace MeteoApi.Services
{
    public class FiveDaysForecastService : IFiveDaysForecastService
    {
        private IWeatherApiConnect _connect;
        private IMapper _mapper;
        private readonly string specURI = "forecast?";

        public FiveDaysForecastService(IWeatherApiConnect connect, IMapper mapper)
        {
            _connect = connect;
            _mapper = mapper;
        }

        public FiveDaysForecastDto GetFiveDaysForecast(string name)
        {
            var forecastFromApi = _connect.GetForecastFromApi<FiveDaysForecast>(specURI, name);

            var forecastDtos = _mapper.Map<List<ForecastDto>>(forecastFromApi.list);

            return new FiveDaysForecastDto(forecastFromApi.city.Name, calculateAverageForecast(forecastDtos));
        }

        private List<ForecastDto> calculateAverageForecast(List<ForecastDto> forecastDtos)
        {
            List<ForecastDto> inMemory = new List<ForecastDto>();
            List<ForecastDto> final = new List<ForecastDto>();
            for (int i = forecastDtos.Count - 1; i >= 0; i--) 
            {
                if (i == forecastDtos.Count - 1)
                {
                    inMemory.Add(forecastDtos[i]);
                }
                else
                {
                    if (forecastDtos[i].dt.Equals(forecastDtos[i + 1].dt) && i != 0)
                    {
                        inMemory.Add(forecastDtos[i]);
                    }
                    else
                    {
                        ForecastDto forecastDto = new ForecastDto(inMemory[0].dt, temperatureAverage(inMemory), cloudAverage(inMemory), rainAverage(inMemory), imageAverage(inMemory));
                        final.Insert(0, forecastDto);
                        inMemory.Clear();
                        inMemory.Add(forecastDtos[i]);
                    }
                }
            }
            return final;
        }
        private double temperatureAverage(List<ForecastDto> inMemory)
        {
            List<double> temperature = new List<double>();
            temperature = inMemory.Select(forecastDto => {
                return forecastDto.temp;
                }).ToList();
            double sumTemp = 0;
            foreach (double temp in temperature) 
            {
                sumTemp += temp;
            }
            return Math.Round((sumTemp / temperature.Count), 1);
        }

        private string imageAverage(List<ForecastDto> inMemory) 
        {
            Clouds cloudsForImage = new Clouds(cloudAverage(inMemory));
            RainFiveDays rainForImage = new RainFiveDays(rainAverage(inMemory));

            return cloudsForImage.GetCloudImage(rainForImage);
        }

        private double rainAverage(List<ForecastDto> inMemory)
        {
            List<double> rains = new List<double>();
            rains = inMemory.Select(forecastDto =>
            {
                return forecastDto.rain;
            }).ToList();


            double sumRains = 0;
            foreach (double rain in rains)
            {
                sumRains += rain;
            }
            return Math.Round((sumRains / rains.Count), 1);
        }

        private int cloudAverage(List<ForecastDto> inMemory)
        {
            List<int> clouds = new List<int>();
            clouds = inMemory.Select(forecastDto =>
            {
                return forecastDto.cloud;
            }).ToList();


            int sumClouds = 0;
            foreach (int cloud in clouds)
            {
                sumClouds += cloud;
            }
            return sumClouds / clouds.Count;
        }

            private double checkRain(RainFiveDays rain)
        {
            if (rain != null)
            {
                return rain.rain;
            }
            else
            {
                return 0;
            }
        }
    }

}
