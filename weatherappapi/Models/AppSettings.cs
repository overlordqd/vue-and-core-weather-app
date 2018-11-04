using System;
using System.Collections.Generic;
using System.Globalization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace weatherappapi.models {
    public class AppSettings {
        [JsonProperty ("AllowedHosts")]
        public string AllowedHosts { get; set; }

        [JsonProperty ("AerisWeather")]
        public AerisWeather AerisWeather { get; set; }
    }

    public struct AerisWeather {
        [JsonProperty ("ApiAddress")]
        public Uri ApiAddress { get; set; }

        [JsonProperty ("ClientId")]
        public string ClientId { get; set; }

        [JsonProperty ("ClientSecret")]
        public string ClientSecret { get; set; }

        [JsonProperty ("Queries")]
        public Queries Queries { get; set; }
    }

    public struct Queries {
        [JsonProperty ("Forecast")]
        public string Forecast { get; set; }

        [JsonProperty ("Current")]
        public string Current { get; set; }
    }
}