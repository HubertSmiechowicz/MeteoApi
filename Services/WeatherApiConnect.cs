using Microsoft.Extensions.Configuration;
using System.Text.Json;
using Newtonsoft.Json;
using MeteoApi.Models;
using System.Security.Principal;
using MeteoApi.Models.monthly;

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
    }
}