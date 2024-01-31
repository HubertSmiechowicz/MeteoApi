using Microsoft.Extensions.Configuration;
using System.Text.Json;
using Newtonsoft.Json;
using MeteoApi.Models;
using System.Security.Principal;
using MeteoApi.Services.Interfaces;

namespace MeteoApi.Services
{
    public class WeatherApiConnect : IWeatherApiConnect
    {

        private static HttpClient client = new HttpClient();
        private readonly string baseURI = "https://api.openweathermap.org/data/2.5/";

        private string GetApiKey()
        {

            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("Properties/apiKeys.json");

            var configuration = builder.Build();
            return configuration["ApiKey"];
        }

        private HttpResponseMessage connectWeatherApi(string specURI, string cityName)
        {
            return client.GetAsync(baseURI + specURI + $"q={cityName}&appid={GetApiKey()}&lang=pl").Result;
        }

        private HttpResponseMessage connectWeatherApi(string specURI, double lat, double lon)
        {
            return client.GetAsync(baseURI + specURI + $"lat={lat}&lon={lon}&appid={GetApiKey()}&lang=pl").Result;
        }

        private HttpResponseMessage connectWeatherApi(string cityName)
        {
            return client.GetAsync("https://api.openweathermap.org/geo/1.0/direct?" + $"q={cityName}&appid={GetApiKey()}&lang=pl").Result;
        }

        public T GetForecastFromApi<T>(string specURI, string cityName)
        {
            T forecast = default(T);
            HttpResponseMessage response = connectWeatherApi(specURI, cityName);
            if (response != null)
                {
                    if (response.IsSuccessStatusCode)
                    {
                        string jsonRespone = response.Content.ReadAsStringAsync().Result;
                        forecast = JsonConvert.DeserializeObject<T>(jsonRespone);
                    }
                    else
                    {
                        Console.WriteLine(response.StatusCode);
                    }
                      
                }
            return forecast; 
        }

        public T GetForecastFromApi<T>(string specURI, double lat, double lon)
        {
            T forecast = default(T);
            HttpResponseMessage response = connectWeatherApi(specURI, lat, lon);
            if (response != null)
            {
                if (response.IsSuccessStatusCode)
                {
                    string jsonRespone = response.Content.ReadAsStringAsync().Result;
                    forecast = JsonConvert.DeserializeObject<T>(jsonRespone);
                }
                else
                {
                    Console.WriteLine(response.StatusCode);
                }

            }
            return forecast;
        }

        public T GetGeocoding<T>(string cityName)
        {
            T geocoding = default(T);
            HttpResponseMessage response = connectWeatherApi(cityName);
            if (response != null)
            {
                if (response.IsSuccessStatusCode)
                {
                    string jsonRespone = response.Content.ReadAsStringAsync().Result;
                    geocoding = JsonConvert.DeserializeObject<T>(jsonRespone);
                }
                else
                {
                    Console.WriteLine(response.StatusCode);
                }

            }
            return geocoding;
        }
    }
}