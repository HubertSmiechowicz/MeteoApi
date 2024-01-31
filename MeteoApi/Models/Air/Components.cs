using Newtonsoft.Json;

namespace MeteoApi.Models.Air
{
    public class Components
    {
        [JsonProperty("co")]
        public double Co { get; private set; }
        [JsonProperty("no")]
        public double No { get; private set; }
        [JsonProperty("no2")]
        public double No2 { get; private set; }
        [JsonProperty("o3")]
        public double O3 { get; private set; }
        [JsonProperty("so2")]
        public double So2 { get; private set; }
        [JsonProperty("pm2_5")]
        public double Pm2_5 { get; private set; }
        [JsonProperty("nh3")]
        public double Nh3 { get; private set; }

        public Components() { }

        public Components(double co, double no, double no2, double o3, double so2, double nh3)
        {
            Co = co;
            No = no;
            No2 = no2;
            O3 = o3;
            So2 = so2;
            Nh3 = nh3;
        }
    }
}
