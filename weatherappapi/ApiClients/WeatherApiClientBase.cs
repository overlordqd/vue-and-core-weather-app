using System;
using System.Linq;

namespace weatherappapi.ApiClients
{
    public abstract class WeatherApiClientBase
    {
        public struct Types
        {
            public const string Current = "Current";
            public const string Forecast = "Forecast";
            public const string LocationKey = "LocationKey";
        }

        protected void ValidateRequest(string weatherCallType)
        {
            if (this is IWeatherApiClient weatherApiClient)
            {
                if (!weatherApiClient.SupportedCalls.Contains(weatherCallType))
                {
                    throw new Exception($" {weatherApiClient.GetType()} - not known weather call: {weatherCallType}");
                }
            }
        }
    }
}
