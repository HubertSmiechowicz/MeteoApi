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
                1 => "https://www.dropbox.com/scl/fi/0uh9nao1pbqkc7gjmykvg/laugh.svg?rlkey=58l3urgziskccye3h78i26pn4&raw=1",
                2 => "https://www.dropbox.com/scl/fi/u5sr30m7s7s1o17ojnx1m/smile.svg?rlkey=m2hme38ciwv3n70l9ei68u594&raw=1",
                3 => "https://www.dropbox.com/scl/fi/xc8a0r0m2b0xrlg0wwxt4/meh.svg?rlkey=uyeq2ipa5453g78tgmiknd76m&raw=1",
                4 => "https://www.dropbox.com/scl/fi/24d1ueqxr316y2l7ob39w/frown.svg?rlkey=y4l2k58gq935hq5j9mpockn6m&raw=1",
                5 => "https://www.dropbox.com/scl/fi/49iy74nllg2y9ula8mnr2/angry.svg?rlkey=75czxeidqjarhm8zzyf2109xr&raw=1",
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
