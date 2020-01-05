using System.Collections.Generic;
using System.Threading.Tasks;

namespace weatherappapi.ApiClients
{
    public interface IWeatherApiClient
    {
        Task<string> GetWeather(string cityName, string callType, params KeyValuePair<string,string>[] extraParameters);
        IEnumerable<string> SupportedCalls { get; }
    }
}