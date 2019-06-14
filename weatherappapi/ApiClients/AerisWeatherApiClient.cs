using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using weatherappapi.ApiCalls;
using weatherappapi.models;
using weatherappapi.Repositories;

namespace weatherappapi.ApiClients
{
    public class AerisWeatherApiClient : WeatherApiClientBase, IWeatherApiClient
    {
        private readonly AppSettings appSettings;
        private readonly IWeatherApiCallFactory weatherApiCallFactory;

        public AerisWeatherApiClient(IAppSettingsWrapper appSettingsWrapper, IWeatherApiCallFactory weatherApiCallFactory)
        {
            appSettings = appSettingsWrapper.AppSettings;
            this.weatherApiCallFactory = weatherApiCallFactory;
        }

        private string ConstructRequestUrl(string weatherCallType, string cityName, params KeyValuePair<string,string>[] extraParameters)
        {
            ValidateRequest(weatherCallType);

            var apiCall = weatherApiCallFactory.GetRequestedApiCall(weatherCallType);

            return apiCall.ConstructApiCallUri(cityName, extraParameters);
        }

        public async Task<string> GetWeather(string cityName, string callType, params KeyValuePair<string,string>[] extraParameters)
        {
            using (var client = new HttpClient())
            {
                using (var request = new HttpRequestMessage(HttpMethod.Get, ConstructRequestUrl(callType, cityName, extraParameters)))
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