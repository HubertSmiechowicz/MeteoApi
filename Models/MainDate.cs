using System.Globalization;
using System.Text.Json.Serialization;
using Newtonsoft.Json;

namespace MeteoApi.Models
{
    public class MainDate
    {
        [JsonProperty("temp")]
        public string temp { get; private set; }

        [JsonProperty("feels_like")]
        public string feels_like { get; private set; }
        [JsonProperty("temp_min")]
        public string temp_min { get; private set; }
        [JsonProperty("temp_max")]
        public string temp_max { get; private set; }

        [JsonProperty("pressure")]
        public string pressure { get; private set; }
        [JsonProperty("humidity")]
        public string humidity { get; private set; }

        public MainDate(string temp, string feels_like, string temp_min, string temp_max, string pressure, string humidity)
        {
            this.temp = temp;
            this.feels_like = feels_like;
            this.temp_min = temp_min;
            this.temp_max = temp_max;
            this.pressure = pressure;
            this.humidity = humidity;
        }

        public void CalculateTemp(string temperatureString, out double tempRounded)
        {
            double temperature;
            double.TryParse(temperatureString, System.Globalization.CultureInfo.InvariantCulture, out temperature);
            temperature -= 273.15;
            tempRounded = Math.Round(temperature, 1);
        }
    }
}
