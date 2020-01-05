using AutoMapper;
using Microsoft.AspNetCore.Hosting;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using weatherappapi.models;
using weatherappapi.Repositories;

namespace weatherappapi
{
    public class LocationsRepository : RepositoryBase, ILocationsRepository
    {
        private readonly IWebHostEnvironment hostingEnvironment;
        private readonly string contentRootPath;
        private IEnumerable<CityModel> _cityList;

        public LocationsRepository(IAppSettingsWrapper appSettingsWrapper,
            IWebHostEnvironment hostingEnvironment,
            IMapper mapper) : base(mapper, appSettingsWrapper)
        {
            this.hostingEnvironment = hostingEnvironment;
            contentRootPath = hostingEnvironment.ContentRootPath;
        }

        private IEnumerable<CityModel> CityList
        {
            get
            {
                if (_cityList != null)
                    return _cityList;

                var citiesJsonFilePath = Path.Combine(contentRootPath, @"data\cities.json");

                if (!File.Exists(citiesJsonFilePath))
                {
                    throw new Exception($"Can't find the cities json file in the specified directory: {citiesJsonFilePath}");
                }

                var fileContent = File.ReadAllText(citiesJsonFilePath);
                var citiesArray = JObject.Parse(fileContent).Value<JArray>("cities");

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