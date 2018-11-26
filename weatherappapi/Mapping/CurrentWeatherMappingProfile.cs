using System.Collections.Generic;
using AutoMapper;
using Newtonsoft.Json.Linq;
using weatherappapi.models;

namespace weatherappapi.mapping {
    public class CurrentWeatherMappingProfile : Profile {
        public CurrentWeatherMappingProfile() {
            CreateMap<JToken, CurrentWeatherModel>()
            .ForMember(x => x.Humidity, y => y.MapFrom(j => j.SelectToken(".response.ob.humidity")))
            .ForMember(x => x.Temperature, y => y.MapFrom(j => j.SelectToken(".response.ob.tempC")))
            .ForMember(x => x.WeatherEvent, y => y.MapFrom(j => j.SelectToken(".response.ob.weather")))
            .ForMember(x => x.WindSpeed, y => y.MapFrom(j => j.SelectToken(".response.ob.windSpeedKPH")))
            .ForMember(x => x.Icon, y => y.MapFrom(j => j.SelectToken(".response.ob.icon")));
        }
    }
}