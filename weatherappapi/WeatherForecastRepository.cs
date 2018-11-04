using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.Extensions.Options;
using weatherappapi.models;

namespace weatherappapi {
    public class WeatherForecastRepository :IWeatherForecastRepository {
        private readonly AppSettings appSettings;
        public WeatherForecastRepository (IOptions<AppSettings> appSettings) {
            this.appSettings = appSettings.Value;
        }

        public async Task<CurrentWeatherResponseModel> GetCurrentWeather (string cityName) {
            using (var httpClient = new HttpClient ()) {
                var requestUrl = appSettings.AerisWeather.ApiAddress +
                    appSettings.AerisWeather.Queries.Current;
                requestUrl = requestUrl.Replace ("{client_id}", appSettings.AerisWeather.ClientId)
                    .Replace ("{client_secret}", appSettings.AerisWeather.ClientSecret)
                    .Replace ("{location}", cityName);

                var response = await httpClient.GetAsync (requestUrl);

                return await response.Content.ReadAsAsync (typeof (CurrentWeatherResponseModel)) as CurrentWeatherResponseModel;
            }
        }

        public async Task<WeatherForecastResponseModel> GetWeatherForecast (string cityName) {
            using (var httpClient = new HttpClient ()) {
                var requestUrl = appSettings.AerisWeather.ApiAddress +
                    appSettings.AerisWeather.Queries.Forecast;
                requestUrl = requestUrl.Replace ("{client_id}", appSettings.AerisWeather.ClientId)
                    .Replace ("{client_secret}", appSettings.AerisWeather.ClientSecret)
                    .Replace ("{location}", cityName);

                var response = await httpClient.GetAsync (requestUrl);

                return await response.Content.ReadAsAsync (typeof (WeatherForecastResponseModel)) as WeatherForecastResponseModel;
            }
        }
    }
}