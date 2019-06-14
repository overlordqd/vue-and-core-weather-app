using System.Collections.Generic;

namespace weatherappapi.ApiCalls
{
    public interface IWeatherApiCall
    {
        string ConstructApiCallUri(string locationName, params KeyValuePair<string,string>[] extraParameters);
    }
}
