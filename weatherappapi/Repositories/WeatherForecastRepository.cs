using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.Extensions.Options;
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
            var weather = await weatherApiClient.GetWeather(cityName, ApiClients.WeatherApiClientBase.Types.Current);

            return await StreamHelper.DeserializeJsonFrom<CurrentWeatherModel>(mapper, weather);
        }

        public async Task<List<WeatherForecastModel>> GetWeatherForecast(string cityName)
        {
            var requestUrl = AppSettings.AerisWeather.APIAddress + AppSettings.AerisWeather.Queries["Forecast"];
            requestUrl = requestUrl.Replace("{client_id}", AppSettings.AerisWeather.ClientId)
                .Replace("{client_secret}", AppSettings.AerisWeather.ClientSecret)
                .Replace("{location}", cityName)
                .Replace("{from}", DateTime.Today.AddDays(1).ToString("yyyy-MM-dd"));

            using (var client = new HttpClient())
            {
                using (var request = new HttpRequestMessage(HttpMethod.Get, requestUrl))
                using (var response = await client.SendAsync(request, HttpCompletionOption.ResponseHeadersRead))
                {
                    var stream = await response.Content.ReadAsStreamAsync();
                    if (response.IsSuccessStatusCode)
                        return await StreamHelper.DeserializeJsonFrom<List<WeatherForecastModel>>(mapper, stream, ".response[0].periods");

                    var content = await StreamHelper.StreamToStringAsync(stream);

                    throw new Exception(content);
                }
            }
        }
    }
}