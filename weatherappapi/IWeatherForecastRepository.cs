using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.Extensions.Options;
using weatherappapi.models;

namespace weatherappapi {
    public interface IWeatherForecastRepository {
        Task<CurrentWeatherResponseModel> GetCurrentWeather (string city);
        Task<WeatherForecastResponseModel> GetWeatherForecast (string city);
    }
}