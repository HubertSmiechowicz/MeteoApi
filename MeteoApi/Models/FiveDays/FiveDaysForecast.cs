using Newtonsoft.Json;
using MeteoApi.Models.Cities;

namespace MeteoApi.Models.FiveDays
{
    [Serializable]
    public class FiveDaysForecast
    {
        [JsonProperty("city")]
        public CityJson city { get; private set; }

        [JsonProperty("list")]
        public List<Forecast> list { get; private set; }

        public FiveDaysForecast(CityJson city, List<Forecast> list)
        {
            this.city = city;
            this.list = list;
        }
    }
}
