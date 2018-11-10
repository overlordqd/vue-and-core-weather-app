using System;
using System.Collections.Generic;
using System.Globalization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace weatherappapi.models {
    public class CityModel
    {
        [JsonProperty("name")]
        public string City{ get; set; }   
        [JsonProperty("zip")]
        public string ZipCode {get;set;}
        [JsonProperty("id")]
        public string Id {get;set;}
        [JsonProperty("lat")]
        public string Lat {get;set;}
        [JsonProperty("lon")]
        public string Lon {get;set;}
    }
}