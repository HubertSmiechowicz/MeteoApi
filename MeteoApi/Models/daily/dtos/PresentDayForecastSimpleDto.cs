namespace MeteoApi.Models.Daily.dtos
{
    public class PresentDayForecastSimpleDto
    {

        public string name { get; private set; }
        public double temp { get; private set; }
        public string image { get; private set; }

        public PresentDayForecastSimpleDto(string name, double temp, string image)
        {
            this.name = name;
            this.temp = temp;
            this.image = image;
        }
    }
}
