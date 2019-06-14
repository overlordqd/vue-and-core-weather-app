using System;

namespace weatherappapi.ApiCalls
{
    public class WeatherApiCallFactory : IWeatherApiCallFactory
    {
        private IAppSettingsWrapper appSettingsWrapper;

        public WeatherApiCallFactory(IAppSettingsWrapper appSettingsWrapper){
            this.appSettingsWrapper = appSettingsWrapper;
        }

        public IWeatherApiCall GetRequestedApiCall(string weatherCallType)
        {
            var type = System.Reflection.TypeInfo
            .GetType(GenerateTypeName(weatherCallType), false, true);

            if(type == null)
            {
                return null;
            }

            var instance = Activator.CreateInstance(type, appSettingsWrapper);

            if(instance is IWeatherApiCall weatherApiCall){
                return weatherApiCall;
            }

            return null;
        }

        private string GenerateTypeName(string weatherCallType) => 
            $"{nameof(weatherappapi)}.{nameof(ApiCalls)}.{weatherCallType}WeatherApiCall";
    }
}
