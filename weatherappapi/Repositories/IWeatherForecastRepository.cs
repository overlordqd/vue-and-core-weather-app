using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.Extensions.Options;
using weatherappapi.models;

namespace weatherappapi {
    public interface IWeatherForecastRepository {
        Task<CurrentWeatherModel> GetCurrentWeather (string city);
        Task<List<WeatherForecastModel>> GetWeatherForecast (string city);
    }
}