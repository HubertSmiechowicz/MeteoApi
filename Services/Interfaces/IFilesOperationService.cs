namespace MeteoApi.Services
{
    public interface IFilesOperationService
    {
        T ReadJsonFile<T>(string fileLocation);
    }
}