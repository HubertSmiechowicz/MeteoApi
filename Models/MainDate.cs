using System.Globalization;
using System.Text.Json.Serialization;

namespace MeteoApi.Models
{
    public class MainDate
    {
        [JsonPropertyName("temp")]
        public string temp { get; set; }
        [JsonPropertyName("pressure")]
        public string pressure { get; set; }
        [JsonPropertyName("humidity")]
        public string humidity { get; set; }

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
