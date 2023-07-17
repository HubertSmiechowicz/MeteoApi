namespace MeteoApi.Services
{
    public interface ICitiesService
    {
        List<string> GetCities(string cityNameFragment);

        List<string> GetMainCities();
    }
}