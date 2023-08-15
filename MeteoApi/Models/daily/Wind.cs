using System.Text.Json.Serialization;
using Newtonsoft.Json;

namespace MeteoApi.Models.Daily
{
    public class Wind
    {
        [JsonProperty("speed")]
        public double speed { get; private set; }

        public Wind(double speed)
        {
            this.speed = speed;
        }
    }
}
