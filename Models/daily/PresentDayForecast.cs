using System.Text.Json.Serialization;
using Newtonsoft.Json;

namespace MeteoApi.Models
{
    [Serializable]
    public class PresentDayForecast
    {
        [JsonProperty("name")]
        public string name { get; private set; }

        [JsonProperty("weather")]
        public List<Weather> weather { get; private set; }

        [JsonProperty("main")]
        public MainDate main { get; private set; }

        [JsonProperty("wind")]
        public Wind wind { get; private set; }

        [JsonProperty("clouds")]
        public Clouds clouds { get; private set; }

        [JsonProperty("rain")]
        public Rain rain { get; private set; }

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
