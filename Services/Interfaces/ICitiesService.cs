namespace MeteoApi.Services
{
    public interface ICitiesService
    {
        List<string> GetCities();

        List<string> GetMainCities();
    }
}