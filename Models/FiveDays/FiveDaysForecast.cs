using Newtonsoft.Json;

namespace MeteoApi.Models.monthly
{
    [Serializable]
    public class FiveDaysForecast
    {
        [JsonProperty("city")]
        public City city { get; private set; }

        [JsonProperty("list")]
        public List<Forecast> list { get; private set; }

        public FiveDaysForecast(City city, List<Forecast> list) 
        {
            this.city = city;
            this.list = list;
        }
    }
}
