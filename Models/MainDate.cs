using System.Globalization;
using System.Text.Json.Serialization;
using Newtonsoft.Json;

namespace MeteoApi.Models
{
    public class MainDate
    {
        [JsonProperty("temp")]
        public string temp { get; set; }

        [JsonProperty("feels_like")]
        public string feels_like { get; set; }

        [JsonProperty("temp_max")]
        public string temp_max { get; set; }

        [JsonProperty("pressure")]
        public string pressure { get; set; }
        [JsonProperty("humidity")]
        public string humidity { get; set; }

        public MainDate(string temp, string feels_like, string pressure, string humidity)
        {
            this.temp = temp;
            this.feels_like = feels_like;
            this.pressure = pressure;
            this.humidity = humidity;
        }

        public string Celcius(string tempF)
        {
            double f;
            double.TryParse(tempF, NumberStyles.Any, CultureInfo.InvariantCulture, out f);
            double celcius = f - 273.15;
            celcius = Math.Round(celcius, 2);
            return celcius.ToString();
        }
    }
}
