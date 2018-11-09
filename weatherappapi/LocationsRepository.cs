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

namespace weatherappapi {
    public class LocationsRepository : ILocationsRepository {
        private readonly AppSettings appSettings;
        private readonly IHostingEnvironment hostingEnvironment;
        private readonly string contentRootPath;
        private JArray _cityList;
        public LocationsRepository (IOptions<AppSettings> appSettings, IHostingEnvironment hostingEnvironment) {
            this.appSettings = appSettings.Value;
            this.hostingEnvironment = hostingEnvironment;
            contentRootPath = hostingEnvironment.ContentRootPath;
        }

        private JArray CityList {
            get{
                if(_cityList != null)
                    return _cityList;

                var citiesContent =  File.ReadAllText(Path.Combine(contentRootPath, @"data\cities.json"));
                return _cityList =  JObject.Parse(citiesContent).Value<JArray>("cities");
            }
        }

        public Task<IEnumerable<CityModel>> GetCities(string input)
        {
            var isPostalCode = Regex.IsMatch(input, @"^\d+$");

            return Task.FromResult( 
                    from c in CityList
                    where (isPostalCode && (c.Value<string>("zip")?.StartsWith(input) ?? false))
                    || (c.Value<string>("city")?.StartsWith(input, true, CultureInfo.InvariantCulture) ?? false)
                    group c by c.Value<string>("city") into cG 
                    select new CityModel{
                      City = cG.Key,
                      ZipCode = cG.FirstOrDefault().Value<string>("zip"),
                      Id = cG.FirstOrDefault().Value<string>("id")
                    });
        }
    }
}