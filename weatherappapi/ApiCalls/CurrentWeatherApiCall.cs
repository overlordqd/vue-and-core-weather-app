﻿using System.Collections.Generic;
using weatherappapi.ApiClients;

namespace weatherappapi.ApiCalls
{
    public class CurrentWeatherApiCall : WeatherApiCallBase, IWeatherApiCall
    {
        public CurrentWeatherApiCall(IAppSettingsWrapper appSettingsWrapper)
        : base(appSettingsWrapper, WeatherApiClientBase.Types.Current){
        }

        public string ConstructApiCallUri(string locationName, params KeyValuePair<string, string>[] extraParameters)
        {
            return this.ConstructRequestUrl()
             .Replace("{location}", locationName);
        }
    }
}
