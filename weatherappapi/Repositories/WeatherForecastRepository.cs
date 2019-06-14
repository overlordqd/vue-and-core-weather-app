using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using weatherappapi.ApiClients;
using weatherappapi.models;
using weatherappapi.Repositories;

namespace weatherappapi
{
    public class WeatherForecastRepository : RepositoryBase, IWeatherForecastRepository
    {
        private readonly IWeatherApiClient weatherApiClient;

        public WeatherForecastRepository(IAppSettingsWrapper appSettingsWrapper, IMapper mapper, IWeatherApiClient weatherApiClient)
            : base(mapper, appSettingsWrapper) {
            this.weatherApiClient = weatherApiClient;
        }

        public async Task<CurrentWeatherModel> GetCurrentWeather(string cityName)
        {
            try {
                var weather = await weatherApiClient.GetWeather(cityName, ApiClients.WeatherApiClientBase.Types.Current);
                return await StreamHelper.DeserializeJsonFrom<CurrentWeatherModel>(mapper, weather);
            }
            catch {
                return null;
            }            
        }

        public async Task<List<WeatherForecastModel>> GetWeatherForecast(string city, int days)
        {
            try {
                var weather = await weatherApiClient.GetWeather(city, ApiClients.WeatherApiClientBase.Types.Forecast, 
                    new KeyValuePair<string, string>("from", days.ToString()));
                return await StreamHelper.DeserializeJsonFrom<List<WeatherForecastModel>>(mapper, weather, ".response[0].periods");
            }
            catch {
                return null;
            } 
        }
    }
}