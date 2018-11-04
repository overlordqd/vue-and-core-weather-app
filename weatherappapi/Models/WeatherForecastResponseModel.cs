using System;
using System.Collections.Generic;
using System.Globalization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace weatherappapi.models {

    public partial class WeatherForecastResponseModel {
        [JsonProperty ("success")]
        public bool Success { get; set; }

        [JsonProperty ("error")]
        public object Error { get; set; }

        [JsonProperty ("response")]
        public List<ForecastResponse> Response { get; set; }
    }

    public partial class ForecastResponse {
        [JsonProperty ("periods")]
        public List<Period> Periods { get; set; }
    }

    public partial class Period {
        [JsonProperty ("dateTimeISO")]
        public DateTimeOffset DateTimeIso { get; set; }

        [JsonProperty ("maxTempC")]
        public long MaxTempC { get; set; }

        [JsonProperty ("minTempC")]
        public long MinTempC { get; set; }

        [JsonProperty ("maxHumidity")]
        public long MaxHumidity { get; set; }

        [JsonProperty ("minHumidity")]
        public long MinHumidity { get; set; }

        [JsonProperty ("windSpeedMaxKPH")]
        public long WindSpeedMaxKph { get; set; }

        [JsonProperty ("windSpeedMinKPH")]
        public long WindSpeedMinKph { get; set; }

        [JsonProperty ("weather")]
        public string Weather { get; set; }
    }
}