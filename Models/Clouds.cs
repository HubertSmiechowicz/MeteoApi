using System.Text.Json.Serialization;
using System.Text.Json.Serialization.Metadata;
using Newtonsoft.Json;

namespace MeteoApi.Models
{
    public class Clouds
    {
        [JsonProperty("all")]
        public string all { get; private set; }

        public Clouds(string all)
        {
            this.all = all;
        }

        public string GetCloudImage<T>(T rainAbstract) where T : RainAbstract
        {
            double cloudPercent;
            double.TryParse(all, out cloudPercent);

            string rainString;
            if (rainAbstract != null)
            {
                rainString = rainAbstract.rain;
            }
            else
            {
                rainString = "0";
            }

            double rain;
            double.TryParse(rainString, System.Globalization.CultureInfo.InvariantCulture, out rain);

            if (rain > 0)
            {
                return "src/assets/rain.png";
            }
            if (cloudPercent >= 0 && cloudPercent < 20 && rain == 0)
            {
                return "src/assets/sunny.png";
            }
            else if (cloudPercent >= 20 && cloudPercent < 40 && rain == 0)
            {
                return "src/assets/littleClouds.png";
            }
            else if (cloudPercent >= 40 && cloudPercent < 60 && rain == 0)
            {
                return "src/assets/moreClouds.png";
            }
            else if (cloudPercent >= 60 && cloudPercent < 80 && rain == 0)
            {
                return "src/assets/bigClouds.png";
            }
            else if (cloudPercent >= 80 && cloudPercent <= 100 && rain == 0)
            {
                return "src/assets/hardClouds.png";
            }
            else
            {
                return "";
            }
        }

    }
}
