using Newtonsoft.Json;

namespace MeteoApi.Models.FiveDays
{
    public class RainFiveDays : RainAbstract
    {
        [JsonProperty("3h")]
        public override double rain { get; protected set; }

        public RainFiveDays() { }

        public RainFiveDays(double threeH)
        {
            rain = threeH;
        }
    }
}
