using MeteoApi.Models.monthly;
using Newtonsoft.Json;
using System.Text;

namespace MeteoApi.Services
{
    public class FilesOperationService : IFilesOperationService
    {
        public T ReadJsonFile<T>(string fileLocation)
        {
            var reader = new StreamReader(fileLocation);
            var citiesJson = "";
            try
            {
                var sb = new StringBuilder();
                var line = "";
                while (line != null)
                {
                    line = reader.ReadLine();
                    sb.Append(line);
                }
                citiesJson = sb.ToString();
            }
            catch
            {
                throw new Exception("Error reading file");
            }
            finally
            {
                reader.Close();
            }

            return JsonConvert.DeserializeObject<T>(citiesJson);
        }
    }
}
