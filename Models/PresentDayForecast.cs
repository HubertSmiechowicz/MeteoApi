using System.Text.Json.Serialization;

namespace MeteoApi.Models
{
    public class PresentDayForecast
    {
        [JsonPropertyName("name")]
        public string name { get; set; }
        [JsonPropertyName("weather")]
        public List<Weather> weather { get; set; }
        [JsonPropertyName("main")]
        public MainDate main { get; set; }
        [JsonPropertyName("wind")]
        public Wind wind { get; set; }

        public PresentDayForecast()
        {

        }
        public PresentDayForecast(string name, List<Weather> weather, MainDate main, Wind wind)
        { 
            this.name = name;
            this.weather = weather;
            this.main = main;
            this.wind = wind;
        }

        public override string ToString() 
        {
            return $"Forecast for {name}:\nDescription: {weather[0].description}\nTemperature: {main.Celcius(main.temp)}\nPressure: {main.pressure}\nHumidity: {main.humidity}\nWind speed: {wind.speed}";
        }

    }
}
