namespace MeteoApi.Models.Daily.dtos
{
    public class PresentDayForecastDto
    {
        public string name { get; private set; }
        public string description { get; private set; }
        public double temp { get; private set; }
        public double feelsLike { get; private set; }
        public double tempMax { get; private set; }
        public int pressure { get; private set; }
        public int humidity { get; private set; }
        public double windSpeed { get; private set; }
        public string image { get; private set; }
        public int all { get; private set; }

        public PresentDayForecastDto(string name, string description, double temp, double feelsLike, double tempMax, int pressure, int humidity, double windSpeed, string image, int all)
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
