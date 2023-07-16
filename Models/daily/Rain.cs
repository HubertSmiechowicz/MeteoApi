using System.Text.Json.Serialization;
using Newtonsoft.Json;

namespace MeteoApi.Models
{
    public class Rain : RainAbstract
    {
        [JsonProperty("1h")]
        public override string rain { get; protected set; }

        public Rain() { }

        public Rain(string oneh)
        {
            rain = oneh;
        }
    }
}
