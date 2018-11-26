using System.Collections.Generic;
using AutoMapper;
using Newtonsoft.Json.Linq;
using weatherappapi.models;

namespace weatherappapi.mapping {
    public class WeatherForecastMappingProfile : Profile {
        public WeatherForecastMappingProfile() {
            CreateMap<JToken, List<WeatherForecastModel>>().ConvertUsing<JTokenToListConverter<WeatherForecastModel>>();
            CreateMap<JToken, WeatherForecastModel>()
            .ForMember(x => x.HumidityMin, y => y.MapFrom(j => j.SelectToken(".minHumidity")))
            .ForMember(x => x.HumidityMax, y => y.MapFrom(j => j.SelectToken(".maxHumidity")))
            .ForMember(x => x.TemperatureMin, y => y.MapFrom(j => j.SelectToken(".minTempC")))
            .ForMember(x => x.TemperatureMax, y => y.MapFrom(j => j.SelectToken(".maxTempC")))
            .ForMember(x => x.WindSpeedMin, y => y.MapFrom(j => j.SelectToken(".windSpeedMinKPH")))
            .ForMember(x => x.WindSpeedMax, y => y.MapFrom(j => j.SelectToken(".windSpeedMaxKPH")))
            .ForMember(x => x.WeatherEvent, y => y.MapFrom(j => j.SelectToken(".weather")))
            .ForMember(x => x.Icon, y => y.MapFrom(j => j.SelectToken(".icon")))
            .ForMember(x => x.Date, y => y.MapFrom(j => j.SelectToken(".dateTimeISO")));
        }
    }
}