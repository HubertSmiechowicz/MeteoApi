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

    }
}
