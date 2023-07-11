using System.Text.Json.Serialization;
using Newtonsoft.Json;

namespace MeteoApi.Models
{
    [Serializable]
    public class PresentDayForecast
    {
        [JsonProperty("name")]
        public string name { get; set; }

        [JsonProperty("weather")]
        public List<Weather> weather { get; set; }

        [JsonProperty("main")]
        public MainDate main { get; set; }

        [JsonProperty("wind")]
        public Wind wind { get; set; }

        [JsonProperty("clouds")]
        public Clouds clouds { get; set; }

        [JsonProperty("rain")]
        public Rain rain { get; set; }

        public PresentDayForecast()
        {

        }
        public PresentDayForecast(string name, List<Weather> weather, MainDate main, Wind wind, Clouds clouds, Rain rain)
        { 
            this.name = name;
            this.weather = weather;
            this.main = main;
            this.wind = wind;
            this.clouds = clouds;
            this.rain = rain;
        }

    }
}
