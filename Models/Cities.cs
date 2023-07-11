namespace MeteoApi.Models
{
    public class Cities
    {
        private List<string> cities = new List<string>() { "Warszawa", "Łódź", "Kraków", "Lublin", "Poznań", "Wrocław", "Koszalin", "Rzeszów", "Sosnowiec", "Radom", "Zakopane", "Gdańsk", "Gdynia", "Sopot", "Radomsko", "Szczecin", "Katowice" };

        private List<string> mainCities = new List<string>() { "Warszawa", "Łódź", "Kraków", "Wrocław", "Poznań", "Szczecin", "Gdańsk", "Katowice" };

        public List<string> GetCities() { return cities; }

        public List<string> GetMainCities() { return mainCities; }
    }
}
