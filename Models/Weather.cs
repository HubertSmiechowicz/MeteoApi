using System.Text.Json.Serialization;

namespace MeteoApi.Models
{
    public class Weather
    {
        [JsonPropertyName("description")]
        public string description { get; set; }
    }
}
