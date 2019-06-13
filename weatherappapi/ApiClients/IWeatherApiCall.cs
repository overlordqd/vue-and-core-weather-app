namespace weatherappapi.ApiClients
{
    public interface IWeatherApiCall
    {
        string CallType { get; }
        string RequestUri { get; set; }
    }
}
