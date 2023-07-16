namespace MeteoApi.Models.FiveDays.dtos
{
    public class ForecastDto
    {
        public string dt { get; private set; }

        public string temp { get; private set; }

        public string maxTemp { get; private set; }

        public string image { get; private set; }

        public ForecastDto(string dt, string temp, string maxTemp, string image) 
        {
            this.dt = dt;
            this.temp = temp;
            this.maxTemp = maxTemp;
            this.image = image;
        }
    }
}
