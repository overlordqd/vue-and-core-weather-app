namespace weatherappapi.ApiCalls
{
    public interface IWeatherApiCall
    {
        string ConstructApiCallUri(string locationName);
    }
}
