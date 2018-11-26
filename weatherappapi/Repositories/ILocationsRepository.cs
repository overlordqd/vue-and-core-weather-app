using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.Extensions.Options;
using weatherappapi.models;

namespace weatherappapi {
    public interface ILocationsRepository
    {
        Task<IEnumerable<CityModel>> GetCities(string input);
    }
}