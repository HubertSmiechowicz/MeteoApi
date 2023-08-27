using MeteoApi.Models.FiveDays;
using MeteoApi.Services.Interfaces;
using Microsoft.AspNetCore.Mvc.Formatters;
using Newtonsoft.Json;
using System.Runtime.CompilerServices;
using System.Text;

namespace MeteoApi.Services
{
    public class FilesOperationService : IFilesOperationService
    {

        public string FilePath = Path.Combine(Directory.GetParent(Directory.GetCurrentDirectory()).FullName, "MeteoApi", "files", "city.list.json");

        public T ReadJsonFile<T>()
        {
            var reader = new StreamReader(FilePath);
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
