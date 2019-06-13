using System.Threading.Tasks;

namespace weatherappapi.Repositories
{
    public interface IWeatherApiClient
    {
        Task<string> GetWeather(string cityName, string callType);
    }
}