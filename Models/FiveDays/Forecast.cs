using MeteoApi.Models.FiveDays;
using Newtonsoft.Json;

namespace MeteoApi.Models.monthly
{
    public class Forecast
    {
        [JsonProperty("dt")]
        public long dt { get; private set; }

        [JsonProperty("main")]
        public MainDate main { get; private set; }

        [JsonProperty("clouds")]
        public Clouds clouds { get; private set; }

        [JsonProperty("rain")]
        public RainFiveDays rain { get; private set; }

        public Forecast(long dt, MainDate main, Clouds clouds, RainFiveDays rain)
        {
            this.dt = dt;
            this.main = main;
            this.clouds = clouds;
            this.rain = rain;
        }
    }
}
