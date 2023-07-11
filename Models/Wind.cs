using System.Text.Json.Serialization;
using Newtonsoft.Json;

namespace MeteoApi.Models
{
    public class Wind
    {
        [JsonProperty("speed")]
        public string speed { get; set; }

        public Wind(string speed)
        {
            this.speed = speed;
        }   
    }
}
