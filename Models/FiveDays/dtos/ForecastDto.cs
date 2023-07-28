namespace MeteoApi.Models.FiveDays.dtos
{
    public class ForecastDto
    {
        public string dt { get; private set; }

        public string temp { get; private set; }

        public string image { get; private set; }

        public ForecastDto(long dt, string temp, string image) 
        {
            this.dt = fromUnixToDateTime(dt);
            this.temp = temp;
            this.image = image;
        }

        public ForecastDto(string dt, string temp, string image)
        {
            this.dt = dt;
            this.temp = temp;
            this.image = image;
        }

        private string fromUnixToDateTime(long dt)
        {
            DateTimeOffset dateTimeOffset = DateTimeOffset.FromUnixTimeSeconds(dt);
            return $"{dateTimeOffset.Day}.{dateTimeOffset.Month}.{dateTimeOffset.Year}";
        }
    }
}
