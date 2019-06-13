using System.Collections.Generic;
using System.Threading.Tasks;
using weatherappapi.models;

namespace weatherappapi
{
    public interface IWeatherForecastRepository {
        Task<CurrentWeatherModel> GetCurrentWeather (string city);
        Task<List<WeatherForecastModel>> GetWeatherForecast (string city);
    }
}