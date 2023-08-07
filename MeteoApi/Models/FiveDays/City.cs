using Newtonsoft.Json;

namespace MeteoApi.Models.FiveDays
{
    public class City
    {
        [JsonProperty("name")]
        public string name { get; private set; }

        public City(string name)
        {
            this.name = name;
        }
    }
}
