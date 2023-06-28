using Microsoft.Extensions.Configuration;
using System.Text.Json;

namespace MeteoApi.Services
{
    public class WeatherApiConnect : IWeatherApiConnect
    {

        private static HttpClient client = new HttpClient();
        private readonly string baseURI = "https://api.openweathermap.org/data/2.5/";

        public string GetDataFromApi(string specURI, string cityName)
        {

            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("Properties/apiKeys.json");

            var configuration = builder.Build();
            if (configuration["ApiKey"] != null)
            {
                HttpResponseMessage response = client.GetAsync(baseURI + specURI + $"q={cityName}&appid={configuration["ApiKey"]}").Result;
                if (response != null)
                {
                    if (response.IsSuccessStatusCode)
                    {
                        return response.Content.ReadAsStringAsync().Result;
                        
                    }
                    else
                    {
                        return response.StatusCode.ToString();
                    }
                    }
                    else
                    {
                        throw new NullReferenceException();
                    }
                }
                else
                {
                    throw new NullReferenceException();
                }

            }

        }
    }
