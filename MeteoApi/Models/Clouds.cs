using System.Text.Json.Serialization;
using System.Text.Json.Serialization.Metadata;
using Newtonsoft.Json;

namespace MeteoApi.Models
{
    public class Clouds
    {
        [JsonProperty("all")]
        public int all { get; private set; }

        public Clouds(int all)
        {
            this.all = all;
        }

        public string GetCloudImage<T>(T rainAbstract) where T : RainAbstract
        {
            double rain;
            if (rainAbstract != null)
            {
                rain = rainAbstract.rain;
            }
            else
            {
                rain = 0;
            }

            if (rain > 0)
            {
                return "/src/assets/rain.png";
            }
            if (all >= 0 && all < 20 && rain == 0)
            {
                return "/src/assets/sunny.png";
            }
            else if (all >= 20 && all < 40 && rain == 0)
            {
                return "/src/assets/littleClouds.png";
            }
            else if (all >= 40 && all < 60 && rain == 0)
            {
                return "/src/assets/moreClouds.png";
            }
            else if (all >= 60 && all < 80 && rain == 0)
            {
                return "/src/assets/bigClouds.png";
            }
            else if (all >= 80 && all <= 100 && rain == 0)
            {
                return "/src/assets/hardClouds.png";
            }
            else
            {
                return "";
            }
        }

    }
}
