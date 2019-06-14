using weatherappapi.ApiClients;

namespace weatherappapi.ApiCalls
{
    public class CurrentWeatherApiCall : WeatherApiCallBase, IWeatherApiCall
    {
        public CurrentWeatherApiCall(IAppSettingsWrapper appSettingsWrapper)
        : base(appSettingsWrapper, WeatherApiClientBase.Types.Current){
        }

        public string ConstructApiCallUri(string locationName)
        {
            return this.ConstructRequestUrl()
             .Replace("{location}", locationName);
        }
    }
}
