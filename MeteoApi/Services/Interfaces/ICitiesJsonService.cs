namespace MeteoApi.Services.Interfaces
{
    public interface ICitiesJsonService
    {
        List<string> GetCities(string cityNameFragment);
    }
}