using Newtonsoft.Json;

namespace MeteoApi.Models.Cities
{
    [Serializable]
    public class CityJson
    {
        [JsonProperty("name")]
        public string Name { get; private set; }


        public CityJson(string name)
        {
            Name = name;
        }

        public override string ToString()
        {
            return $"{Name}\n";
        }
    }
}
