using System.Collections.Generic;
using AutoMapper;
using Newtonsoft.Json.Linq;
using weatherappapi.models;

namespace weatherappapi.mapping {
    public class CityModelMappingProfile : Profile {
        public CityModelMappingProfile() {
            CreateMap<JToken, List<CityModel>>().ConvertUsing<JTokenToListConverter<CityModel>>();
            CreateMap<JToken, CityModel>()
            .ForMember(x => x.Id, y => y.MapFrom(j => j.SelectToken(".id")))
            .ForMember(x => x.Lat, y => y.MapFrom(j => j.SelectToken(".lat")))
            .ForMember(x => x.Lon, y => y.MapFrom(j => j.SelectToken(".lon")))
            .ForMember(x => x.Name, y => y.MapFrom(j => j.SelectToken(".city")))
            .ForMember(x => x.ZipCode, y => y.MapFrom(j => j.SelectToken(".zip")));        
        }
    }
}