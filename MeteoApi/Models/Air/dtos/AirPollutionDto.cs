namespace MeteoApi.Models.Air.dtos
{
    public class AirPollutionDto
    {
        public string? descriptionPollution { get; private set; }
        public string? imagePollution { get; private set; }
        public double Co { get; private set; }
        public double No { get; private set; }
        public double No2 { get; private set; }
        public double O3 { get; private set; }
        public double So2 { get; private set; }
        public double Pm2_5 { get; private set; }
        public double Nh3 { get; private set; }
    }
}
