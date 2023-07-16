using Newtonsoft.Json;

namespace MeteoApi.Models
{
    [Serializable]
    public class CityApi
    {
        [JsonProperty("name")]
        public string Name { get; private set; }


        public CityApi(string name)
        {
            Name = name;
        }
    }
}
