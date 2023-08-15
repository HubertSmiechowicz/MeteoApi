using System.Text.Json.Serialization;
using Newtonsoft.Json;

namespace MeteoApi.Models.Daily
{
    public class Rain : RainAbstract
    {
        [JsonProperty("1h")]
        public override double rain { get; protected set; }

        public Rain() { }

        public Rain(double oneh)
        {
            rain = oneh;
        }
    }
}
