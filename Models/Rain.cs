using System.Text.Json.Serialization;
using Newtonsoft.Json;

namespace MeteoApi.Models
{
    public class Rain
    {
        [JsonProperty("1h")]
        public string oneh { get; set; }

        public Rain(string oneh) 
        {
            this.oneh = oneh;
        }
    }
}
