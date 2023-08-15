using System.Globalization;
using System.Text.Json.Serialization;
using Newtonsoft.Json;

namespace MeteoApi.Models
{
    public class MainDate
    {
        [JsonProperty("temp")]
        public double temp { get; private set; }

        [JsonProperty("feels_like")]
        public double feels_like { get; private set; }
        [JsonProperty("temp_min")]
        public double temp_min { get; private set; }
        [JsonProperty("temp_max")]
        public double temp_max { get; private set; }

        [JsonProperty("pressure")]
        public int pressure { get; private set; }
        [JsonProperty("humidity")]
        public int humidity { get; private set; }

        public MainDate(double temp, double feels_like, double temp_min, double temp_max, int pressure, int humidity)
        {
            this.temp = temp;
            this.feels_like = feels_like;
            this.temp_min = temp_min;
            this.temp_max = temp_max;
            this.pressure = pressure;
            this.humidity = humidity;
        }

        public double CalculateTemp(double temperature)
        {
            return Math.Round(temperature -= 273.15, 2);
        }
    }
}
