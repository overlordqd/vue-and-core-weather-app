using System.Collections.Generic;
using weatherappapi.ApiClients;

namespace weatherappapi.ApiCalls
{
    public class LocationKeyApiCall : WeatherApiCallBase, IWeatherApiCall
    {
        public LocationKeyApiCall(IAppSettingsWrapper appSettingsWrapper)
        : base(appSettingsWrapper, WeatherApiClientBase.Types.LocationKey){
        }

        public string ConstructApiCallUri(string locationName, params KeyValuePair<string, string>[] extraParameters)
        {
            return this.ConstructRequestUrl()
             .Replace("{location}", locationName);
        }
    }
}
