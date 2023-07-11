﻿using System.Text.Json.Serialization;
using Newtonsoft.Json;

namespace MeteoApi.Models
{
    public class Weather
    {
        [JsonProperty("description")]
        public string description { get; set; }

        public Weather(string description)
        {
            this.description = description;
        }
    }
}
