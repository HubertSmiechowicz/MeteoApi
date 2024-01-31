using Newtonsoft.Json;

namespace MeteoApi.Models.Air
{
    public class Main
    {
        [JsonProperty("aqi")]
        public int Aqi { get; private set; }

        public Main() { }  

        public Main(int aqi) 
        {
            Aqi = aqi;
        }

        public string GetPollutionImage(int aqi) 
        {
            return aqi switch
            {
                1 => "/src/assets/laugh.svg",
                2 => "/src/assets/smile.svg",
                3 => "/src/assets/meh.svg",
                4 => "/src/assets/frown.svg",
                5 => "/src/assets/angry.svg",
                _ => "",
            };
        }

        public string GetPollutionDescription(int aqi) 
        {
            return aqi switch
            {
                1 => "Doskonałe",
                2 => "Dobre",
                3 => "Umiarkowane",
                4 => "Złe",
                5 => "Bardzo złe",
                _ => "",
            };
        }
    }
}
