using Newtonsoft.Json;

namespace MeteoApi.Models.Air
{
    public class AirPollutionList
    {
        [JsonProperty("list")]
        public List<AirPollution> List { get; private set; }
    }
}
