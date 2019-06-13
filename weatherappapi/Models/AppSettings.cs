using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace weatherappapi.models
{
    public class AppSettings {
        [JsonProperty ("AllowedHosts")]
        public string AllowedHosts { get; set; }

        public APIConfiguration CitiesAPI {get;set; }

        [JsonProperty ("AerisWeather")]
        public AerisWeather AerisWeather { get; set; }
    }

    public class APIConfiguration
    {
        public Uri APIAddress {get;set;}
        public Dictionary<string, string> Queries {get; set;}
    }

    public class AerisWeather : APIConfiguration {
        public string ClientId { get; set; }
        public string ClientSecret { get; set; }
    }
}