using System;
using System.Collections.Generic;

namespace weatherappapi.ApiClients
{
    public class CurrentWeatherApiCall : IWeatherApiCall
    {
        public string RequestUri { get;set; }
        public string CallType { 
            get =>  "Current";
        }

        public string ConstructApiCallUri(Dictionary<string, string> parameters)
        {
            throw new NotImplementedException();
        }
    }
}
