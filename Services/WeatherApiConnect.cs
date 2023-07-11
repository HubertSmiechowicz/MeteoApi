using Microsoft.Extensions.Configuration;
using System.Text.Json;
using Newtonsoft.Json;
using MeteoApi.Models;
using System.Security.Principal;

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

        public PresentDayForecast GetPresentDayForecastFromApi(string specURI, string cityName)
        {
            var presentDayForecast = new PresentDayForecast();
            HttpResponseMessage response = connectWeatherApi(specURI, cityName);
            if (response != null)
                {
                    if (response.IsSuccessStatusCode)
                    {
                        string jsonRespone = response.Content.ReadAsStringAsync().Result;
                        presentDayForecast = JsonConvert.DeserializeObject<PresentDayForecast>(jsonRespone);
                    }
                      
                }
            return presentDayForecast;
        }
    }
}