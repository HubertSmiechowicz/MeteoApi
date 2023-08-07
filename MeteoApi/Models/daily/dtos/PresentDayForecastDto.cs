namespace MeteoApi.Models.daily.dtos
{
    public class PresentDayForecastDto
    {
        public string name { get; private set; }
        public string description { get; private set; }
        public string temp { get; private set; }
        public string feelsLike { get; private set; }
        public string tempMax { get; private set; }
        public string pressure { get; private set; }
        public string humidity { get; private set; }
        public string windSpeed { get; private set; }
        public string image { get; private set; }

        public string all { get; private set; }

        public PresentDayForecastDto(string name, string description, string temp, string feelsLike, string tempMax, string pressure, string humidity, string windSpeed, string image, string all)
        {
            this.name = name;
            this.description = description;
            this.temp = temp;
            this.feelsLike = feelsLike;
            this.tempMax = tempMax;
            this.pressure = pressure;
            this.humidity = humidity;
            this.windSpeed = windSpeed;
            this.image = image;
            this.all = all;
        }
    }
}
