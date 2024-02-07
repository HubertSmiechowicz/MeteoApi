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
                return "https://www.dropbox.com/scl/fi/f11jnd351bk78zs7bfgw7/rain.png?rlkey=pjv771u4xfziik4shzdevxqm1&dl=1";
            }
            if (all >= 0 && all < 20 && rain == 0)
            {
                return "https://www.dropbox.com/scl/fi/0xl6tpppg3xwf8l7ul8cc/sunny.png?rlkey=hpptbk3d92du6kwlwdxrt7zwb&dl=1";
            }
            else if (all >= 20 && all < 40 && rain == 0)
            {
                return "https://www.dropbox.com/scl/fi/1sqw2taj03p6q962s0u0u/littleClouds.png?rlkey=fa5pcckr8gkrar93n7i2ai4xc&dl=1";
            }
            else if (all >= 40 && all < 60 && rain == 0)
            {
                return "https://www.dropbox.com/scl/fi/rx63musym67whea840ubv/moreClouds.png?rlkey=9moq91ifj1u2j728v7xu1unre&dl=1";
            }
            else if (all >= 60 && all < 80 && rain == 0)
            {
                return "https://www.dropbox.com/scl/fi/ypinqw62w4v7553dj55kf/bigClouds.png?rlkey=svwqs7h58ms4s8pf5ikq9g0bu&dl=1";
            }
            else if (all >= 80 && all <= 100 && rain == 0)
            {
                return "https://www.dropbox.com/scl/fi/nwsp4eif1l6mzju57h9kz/hardClouds.png?rlkey=yvpzpumoyz78ocf1t1u7c3dae&dl=1";
            }
            else
            {
                return "";
            }
        }

    }
}
