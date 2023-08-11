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

                return new ForecastDto(forecast.dt, tempRounded.ToString(), forecast.clouds.all, checkRain(forecast.rain), forecast.clouds.GetCloudImage(forecast.rain));
            }).ToList();

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

        private string imageAverage(List<ForecastDto> inMemory) 
        {
            Clouds cloudsForImage = new Clouds(cloudAverage(inMemory));
            RainFiveDays rainForImage = new RainFiveDays(rainAverage(inMemory));

            return cloudsForImage.GetCloudImage(rainForImage);
        }

        private string rainAverage(List<ForecastDto> inMemory)
        {
            List<double> rains = new List<double>();
            rains = inMemory.Select(forecastDto =>
            {
                double rain;
                double.TryParse(forecastDto.rain, System.Globalization.CultureInfo.InvariantCulture, out rain);
                return rain;
            }).ToList();


            double sumRains = 0;
            foreach (double rain in rains)
            {
                sumRains += rain;
            }
            return Math.Round((sumRains / rains.Count), 1).ToString();
        }

        private string cloudAverage(List<ForecastDto> inMemory)
        {
            List<double> clouds = new List<double>();
            clouds = inMemory.Select(forecastDto =>
            {
                double all;
                double.TryParse(forecastDto.cloud, System.Globalization.CultureInfo.InvariantCulture, out all);
                return all;
            }).ToList();


            double sumClouds = 0;
            foreach (double cloud in clouds)
            {
                sumClouds += cloud;
            }
            return Math.Round((sumClouds / clouds.Count), 1).ToString();
        }

            private string checkRain(RainFiveDays rain)
        {
            if (rain != null)
            {
                return rain.rain;
            }
            else
            {
                return "0";
            }
        }
    }

}
