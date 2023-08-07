namespace MeteoApi.Services.Interfaces
{
    public interface IFilesOperationService
    {
        T ReadJsonFile<T>(string fileLocation);
    }
}