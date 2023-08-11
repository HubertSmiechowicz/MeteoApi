using System.Text.Json.Serialization;
using Newtonsoft.Json;

namespace MeteoApi.Models.Daily
{
    public class Weather
    {
        [JsonProperty("description")]
        public string description { get; private set; }

        public Weather(string description)
        {
            this.description = description;
        }
    }
}
