namespace MeteoApi.Models.dtos
{
    public class PresentDayForecastSimpleDto
    {

        public string name { get; private set; }
        public string temp { get; private set; }
        public string image { get; private set; }

        public PresentDayForecastSimpleDto(string name, string temp, string image)
        {
            this.name = name;
            this.temp = temp;
            this.image = image;
        }
    }
}
