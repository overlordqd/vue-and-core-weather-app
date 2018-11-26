using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using weatherappapi.models;
using System.Globalization;
using AutoMapper;

namespace weatherappapi {
    public class LocationsRepository : ILocationsRepository {
        private readonly AppSettings appSettings;
        private readonly IMapper mapper;
        private readonly IHostingEnvironment hostingEnvironment;
        private readonly string contentRootPath;
        private IEnumerable<CityModel> _cityList;
        public LocationsRepository (IOptions<AppSettings> appSettings, 
            IHostingEnvironment hostingEnvironment,
            IMapper mapper) {
            this.appSettings = appSettings.Value;
            this.hostingEnvironment = hostingEnvironment;
            this.mapper = mapper;
            contentRootPath = hostingEnvironment.ContentRootPath;
        }

        private IEnumerable<CityModel> CityList {
            get {
                if(_cityList != null)
                    return _cityList;

                var fileContent =  File.ReadAllText(Path.Combine(contentRootPath, @"data\cities.json"));
                var citiesArray =  JObject.Parse(fileContent).Value<JArray>("cities");
                
                return _cityList = mapper.Map<List<CityModel>>(citiesArray);
            }
        }

        public Task<IEnumerable<CityModel>> GetCities(string input)
        {
            var isPostalCode = Regex.IsMatch(input, @"^\d+$");

            return Task.FromResult( 
                    from c in CityList
                    where (isPostalCode && (c.ZipCode?.StartsWith(input) ?? false))
                        || (c.Name?.StartsWith(input, true, CultureInfo.InvariantCulture) ?? false)
                    group c by c.Name into cG 
                    select cG.FirstOrDefault());
        }
    }
}