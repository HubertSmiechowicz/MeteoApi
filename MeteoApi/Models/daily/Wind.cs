using System.Text.Json.Serialization;
using Newtonsoft.Json;

namespace MeteoApi.Models.Daily
{
    public class Wind
    {
        [JsonProperty("speed")]
        public string speed { get; private set; }

        public Wind(string speed)
        {
            this.speed = speed;
        }
    }
}
