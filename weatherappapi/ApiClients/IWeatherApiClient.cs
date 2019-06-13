using System.Threading.Tasks;

namespace weatherappapi.ApiClients
{
    public interface IWeatherApiClient
    {
        Task<string> GetWeather(string cityName, string callType);
    }
}