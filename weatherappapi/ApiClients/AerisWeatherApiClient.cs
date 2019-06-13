using System;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using weatherappapi.ApiClients;
using weatherappapi.models;

namespace weatherappapi.Repositories
{
    public class AerisWeatherApiClient : WeatherApiClientBase, IWeatherApiClient
    {
        private readonly AppSettings appSettings;

        public AerisWeatherApiClient(IAppSettingsWrapper appSettingsWrapper)
        {
            appSettings = appSettingsWrapper.AppSettings;
        }

        private string ConstructRequestUrl(string weatherCallType, string cityName)
        {
            if (!new[] { Types.Current, Types.Forecast }.Contains(weatherCallType))
            {
                throw new Exception($"Not known weather call: {weatherCallType}");
            }

            return appSettings.AerisWeather.APIAddress + appSettings.AerisWeather.Queries[weatherCallType]
                    .Replace("{client_id}", appSettings.AerisWeather.ClientId)
                    .Replace("{client_secret}", appSettings.AerisWeather.ClientSecret)
                    .Replace("{location}", cityName);
        }

        public async Task<string> GetWeather(string cityName, string callType)
        {
            using (var client = new HttpClient())
            {
                using (var request = new HttpRequestMessage(HttpMethod.Get, ConstructRequestUrl(callType, cityName)))
                using (var response = await client.SendAsync(request, HttpCompletionOption.ResponseHeadersRead))
                {
                    var stream = await response.Content.ReadAsStreamAsync();
                    var content = await StreamHelper.StreamToStringAsync(stream);

                    if (response.IsSuccessStatusCode)
                        return content;

                    throw new Exception(content);
                }
            }
        }
    }
}
