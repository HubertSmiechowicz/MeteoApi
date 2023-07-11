using System.Text.Json.Serialization;
using System.Text.Json.Serialization.Metadata;
using Newtonsoft.Json;

namespace MeteoApi.Models
{
    public class Clouds
    {
        [JsonProperty("all")]
        public string all { get; set; }

        public Clouds(string all)
        {
            this.all = all;
        }

    }
}
