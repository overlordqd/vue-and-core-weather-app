using System;
using System.Collections.Generic;
using System.Globalization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace weatherappapi.models {

    public partial class CurrentWeatherResponseModel {
        [JsonProperty ("success")]
        public bool Success { get; set; }

        [JsonProperty ("error")]
        public object Error { get; set; }

        [JsonProperty ("response")]
        public CurrentWeatherResponse Response { get; set; }
    }

    public partial class CurrentWeatherResponse {
        [JsonProperty ("ob")]
        public Ob Ob { get; set; }
    }

    public partial class Ob {
        [JsonProperty ("tempC")]
        public long TempC { get; set; }

        [JsonProperty ("humidity")]
        public long Humidity { get; set; }

        [JsonProperty ("weather")]
        public string Weather { get; set; }

        [JsonProperty ("windSpeedKPH")]
        public long WindSpeedKph { get; set; }
    }
}