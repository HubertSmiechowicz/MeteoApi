namespace MeteoApi.Services.Interfaces
{
    public interface ICitiesService
    {
        List<string> GetCities(string cityNameFragment);

        List<string> GetMainCities();
    }
}