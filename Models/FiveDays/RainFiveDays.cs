using Newtonsoft.Json;

namespace MeteoApi.Models.FiveDays
{
    public class RainFiveDays : RainAbstract
    {
        [JsonProperty("3h")]
        public override string rain { get; protected set; }

        public RainFiveDays() { }

        public RainFiveDays(string threeH)
        {
            rain = threeH;
        }
    }
}
