namespace MeteoApi.Models.dtos
{
    public class PresentDayForecastSimpleDto
    {

        public string name { get; set; }
        public string temp { get; set; }
        public string image { get; set; }

        public PresentDayForecastSimpleDto(string name, string temp, string image)
        {
            this.name = name;
            this.temp = temp;
            this.image = image;
        }
    }
}
