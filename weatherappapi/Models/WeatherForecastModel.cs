using System;
using Newtonsoft.Json;

namespace weatherappapi.models {
    public class WeatherForecastModel
    {
        [JsonProperty("date")]
        public DateTime Date { get; set; }

        [JsonProperty("temperatureMin")]
        public int TemperatureMin { get; set; }
        
        [JsonProperty("temperatureMax")]
        public int TemperatureMax { get; set; }

        [JsonProperty("windSpeedMin")]
        public int WindSpeedMin { get; set; }

        [JsonProperty("windSpeedMax")]
        public int WindSpeedMax { get; set; }

        [JsonProperty("humidityMin")]
        public int HumidityMin { get; set; }
        
        [JsonProperty("humidityMax")]
        
        public int HumidityMax { get; set; }
        [JsonProperty("icon")]
        public string Icon { get; set; }
        
        [JsonProperty("weatherEvent")]
        public string WeatherEvent { get; set; }
    }
}