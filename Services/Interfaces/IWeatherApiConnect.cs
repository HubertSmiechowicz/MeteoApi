namespace MeteoApi.Services
{
    public interface IWeatherApiConnect
    {
        string GetDataFromApi(string specURI, string cityName);
    }
}