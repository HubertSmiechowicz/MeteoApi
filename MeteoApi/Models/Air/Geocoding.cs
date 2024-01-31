using Newtonsoft.Json;

namespace MeteoApi.Models.Air
{
    public class Geocoding
    {
        [JsonProperty("lat")]
        public double lat { get; private set; }
        [JsonProperty("lon")]
        public double lon { get; private set; }
    }
}
