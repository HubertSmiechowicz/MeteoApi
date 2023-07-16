namespace MeteoApi.Models
{
    public abstract class RainAbstract
    {

        public abstract string rain { get; protected set; }

        public string getRain<T>(T rainFromApi) where T : RainAbstract
        {
            if (rainFromApi != null)
            {
                rain = rainFromApi.rain;
            }
            else
            {
                rain = "0";
            }

            return rain;
        }
    }
}
