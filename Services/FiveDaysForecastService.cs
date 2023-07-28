using MeteoApi.Models;
using MeteoApi.Models.FiveDays;
using MeteoApi.Models.FiveDays.dtos;
using MeteoApi.Models.monthly;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing.Template;
using System;
using System.Linq;

namespace MeteoApi.Services
{
    public class FiveDaysForecastService : IFiveDaysForecastService
    {
        private IWeatherApiConnect _connect;
        private readonly string specURI = "forecast?";

        public FiveDaysForecastService(IWeatherApiConnect connect)
        {
            _connect = connect;
        }

        public FiveDaysForecastDto GetFiveDaysForecast(string name)
        {
            var forecastFromApi = _connect.GetForecastFromApi<FiveDaysForecast>(specURI, name);

            var forecastDtos = forecastFromApi.list.Select(forecast =>
            {
                double tempRounded;
                forecast.main.CalculateTemp(forecast.main.temp, out tempRounded);

                return new ForecastDto(forecast.dt, tempRounded.ToString(), forecast.clouds.getCloudImage(forecast.rain));
            }).ToList();

            return new FiveDaysForecastDto(forecastFromApi.city.name, calculateAverageForecast(forecastDtos));
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
                    if (forecastDtos[i].dt.Equals(forecastDtos[i + 1].dt))
                    {
                        inMemory.Add(forecastDtos[i]);
                    }
                    else
                    {
                        ForecastDto forecastDto = new ForecastDto(inMemory[0].dt, temperatureAverage(inMemory), inMemory[0].image);
                        final.Insert(0, forecastDto);
                        inMemory.Clear();                    
                    }
                }
            }
            return final;
        }
        private string temperatureAverage(List<ForecastDto> inMemory)
        {
            List<double> temperature = new List<double>();
            temperature = inMemory.Select(forecastDto => {
                double temp;
                double.TryParse(forecastDto.temp, out temp);
                return temp;
                }).ToList();
            double sumTemp = 0;
            foreach (double temp in temperature) 
            {
                sumTemp += temp;
            }
            return Math.Round((sumTemp / temperature.Count), 1).ToString();
        }
    }

}
