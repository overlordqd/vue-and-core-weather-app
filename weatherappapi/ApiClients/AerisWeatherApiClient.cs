﻿using System;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using weatherappapi.models;
using weatherappapi.Repositories;

namespace weatherappapi.ApiClients
{
    public class AerisWeatherApiClient : WeatherApiClientBase, IWeatherApiClient
    {
        private readonly AppSettings appSettings;
        private readonly WeatherApiCallFactory weatherApiCallFactory;

        public AerisWeatherApiClient(IAppSettingsWrapper appSettingsWrapper, WeatherApiCallFactory weatherApiCallFactory)
        {
            appSettings = appSettingsWrapper.AppSettings;
            this.weatherApiCallFactory = weatherApiCallFactory;
        }

        private string ConstructRequestUrl(string weatherCallType, string cityName)
        {
            ValidateRequest(weatherCallType);

            weatherApiCallFactory.


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