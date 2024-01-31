using Newtonsoft.Json;

namespace MeteoApi.Models.Air
{
    public class AirPollution
    {
        [JsonProperty("main")]
        public Main? Main { get; private set; }
        [JsonProperty("components")]
        public Components Components { get; private set; }

        public AirPollution() { }

        public AirPollution(Main? main, Components components) 
        {
            Main = main;
            Components = components;
        }
    }
}
