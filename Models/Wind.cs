using System.Text.Json.Serialization;

namespace MeteoApi.Models
{
    public class Wind
    {
        [JsonPropertyName("speed")]
        public string speed { get; set; }
    }
}
