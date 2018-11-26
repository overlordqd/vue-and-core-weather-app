using Newtonsoft.Json;

namespace weatherappapi.models {
     public class CurrentWeatherModel
    {
        [JsonProperty("temperature")]
        public int Temperature { get; set; }

        [JsonProperty("windSpeed")]
        public int WindSpeed { get; set; }

        [JsonProperty("humidity")]
        public int Humidity { get; set; }
        
        [JsonProperty("icon")]
        public string Icon { get; set; }
        
        [JsonProperty("weatherEvent")]
        public string WeatherEvent { get; set; }
    }
}