using System.Collections.Generic;
using System.Threading.Tasks;
using weatherappapi.models;

namespace weatherappapi
{
    public interface ILocationsRepository
    {
        Task<IEnumerable<CityModel>> GetCities(string input);
    }
}