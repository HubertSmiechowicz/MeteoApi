namespace MeteoApi.Models.FiveDays.dtos
{
    public class ForecastDto
    {
        public string dt { get; private set; }

        public double temp { get; private set; }

        public int cloud { get; private set; }

        public double rain { get; private set; }

        public string image { get; private set; }

        public ForecastDto(long dt, double temp, int cloud, double rain, string image) 
        {
            this.dt = fromUnixToDateTime(dt);
            this.temp = temp;
            this.cloud = cloud;
            this.rain = rain;
            this.image = image;
        }

        public ForecastDto(string dt, double temp, int cloud, double rain, string image)
        {
            this.dt = dt;
            this.temp = temp;
            this.cloud = cloud;
            this.rain = rain;
            this.image = image;
        }

        private string fromUnixToDateTime(long dt)
        {
            DateTimeOffset dateTimeOffset = DateTimeOffset.FromUnixTimeSeconds(dt);
            return $"{dateTimeOffset.Day}.{dateTimeOffset.Month}.{dateTimeOffset.Year}";
        }
    }
}
