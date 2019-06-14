using System.Collections.Generic;
using weatherappapi.ApiClients;

namespace weatherappapi.ApiCalls
{
    public class ForecastWeatherApiCall : WeatherApiCallBase, IWeatherApiCall
    {
        public ForecastWeatherApiCall(IAppSettingsWrapper appSettingsWrapper)
        : base(appSettingsWrapper, WeatherApiClientBase.Types.Forecast){
        }

        public string ConstructApiCallUri(string locationName, params KeyValuePair<string, string>[] extraParameters)
        {
            return this.ConstructRequestUrl(extraParameters)
             .Replace("{location}", locationName);
        }
    }
}
