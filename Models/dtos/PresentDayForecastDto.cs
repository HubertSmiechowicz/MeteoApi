namespace MeteoApi.Models.dtos
{
    public class PresentDayForecastDto
    {
        public string name { get; set; }
        public string description { get; set; }
        public string temp { get; set; }
        public string feelsLike { get; set; }
        public string tempMax { get; set; }
        public string pressure { get; set; }
        public string humidity { get; set; }
        public string windSpeed { get; set; }
        public string rain { get; set; }
        public string image { get; set; }

        public string all { get; set; }

        public PresentDayForecastDto(string name, string description, string temp, string feelsLike, string tempMax, string pressure, string humidity, string windSpeed, string rain, string image, string all) 
        {
            this.name = name;
            this.description = description;
            this.temp = temp;
            this.feelsLike = feelsLike;
            this.tempMax = tempMax;
            this.pressure = pressure;
            this.humidity = humidity;
            this.windSpeed = windSpeed;
            this.rain = rain;
            this.image = image;
            this.all = all;
        }
    }
}
