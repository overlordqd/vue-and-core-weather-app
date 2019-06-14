using System.Collections.Generic;

namespace weatherappapi.ApiCalls
{
    public abstract class WeatherApiCallBase
    {
        private readonly IAppSettingsWrapper appSettingsWrapper;
        private readonly string weatherCallType;

        public WeatherApiCallBase(IAppSettingsWrapper appSettingsWrapper, string weatherCallType){
            this.appSettingsWrapper = appSettingsWrapper;
            this.weatherCallType = weatherCallType;
        }

        protected virtual string ConstructRequestUrl(params KeyValuePair<string, string>[] extraParameters)
        {
            var url = appSettingsWrapper.AppSettings.AerisWeather.APIAddress 
            + appSettingsWrapper.AppSettings.AerisWeather.Queries[weatherCallType]
                    .Replace("{client_id}", appSettingsWrapper.AppSettings.AerisWeather.ClientId)
                    .Replace("{client_secret}", appSettingsWrapper.AppSettings.AerisWeather.ClientSecret);

            foreach(var parameter in extraParameters)
            {
                url = url.Replace($"{{{parameter.Key}}}", parameter.Value);
            }

            return url;
        }
    }
}