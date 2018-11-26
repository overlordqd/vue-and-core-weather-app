using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using weatherappapi.models;

namespace weatherappapi {
    public class WeatherForecastRepository : IWeatherForecastRepository {
        private readonly AppSettings appSettings;
        private readonly IMapper mapper;
        public WeatherForecastRepository (IOptions<AppSettings> appSettings, IMapper mapper) {
            this.appSettings = appSettings.Value;
            this.mapper = mapper;
        }

        private async Task<T> DeserializeJsonFromStream<T>(Stream stream, string startFromToken = null)
        {
            if (stream == null || stream.CanRead == false)
                return default(T);

            using (var sr = new StreamReader(stream))
            using (var jtr = new JsonTextReader(sr))
            {
                var jsonObject = await JObject.ReadFromAsync(jtr);
                if(startFromToken != null)
                    jsonObject = jsonObject.SelectToken(startFromToken);
                return mapper.Map<T>(jsonObject);
            }
        }

        private static async Task<string> StreamToStringAsync(Stream stream)
        {
            string content = null;

            if (stream != null)
                using (var sr = new StreamReader(stream))
                    content = await sr.ReadToEndAsync();

            return content;
        }

        public async Task<CurrentWeatherModel> GetCurrentWeather (string cityName) {
            var requestUrl = appSettings.AerisWeather.APIAddress + appSettings.AerisWeather.Queries["Current"];
            requestUrl = requestUrl.Replace("{client_id}", appSettings.AerisWeather.ClientId)
                    .Replace("{client_secret}", appSettings.AerisWeather.ClientSecret)
                    .Replace("{location}", cityName);

            using (var client = new HttpClient ()) {
                using (var request = new HttpRequestMessage(HttpMethod.Get, requestUrl))
                using (var response = await client.SendAsync(request, HttpCompletionOption.ResponseHeadersRead))
                {
                    var stream = await response.Content.ReadAsStreamAsync();
                    if (response.IsSuccessStatusCode)
                        return await DeserializeJsonFromStream<CurrentWeatherModel>(stream);

                    var content = await StreamToStringAsync(stream);
                    
                    throw new Exception(content);
                }
            }
        }

        public async Task<List<WeatherForecastModel>> GetWeatherForecast (string cityName) {
            var requestUrl = appSettings.AerisWeather.APIAddress + appSettings.AerisWeather.Queries["Forecast"];
            requestUrl = requestUrl.Replace ("{client_id}", appSettings.AerisWeather.ClientId)
                .Replace ("{client_secret}", appSettings.AerisWeather.ClientSecret)
                .Replace ("{location}", cityName)
                .Replace ("{from}", DateTime.Today.AddDays(1).ToString("yyyy-MM-dd"));

            using (var client = new HttpClient ()) {
                using (var request = new HttpRequestMessage(HttpMethod.Get, requestUrl))
                using (var response = await client.SendAsync(request, HttpCompletionOption.ResponseHeadersRead))
                {
                    var stream = await response.Content.ReadAsStreamAsync();
                    if (response.IsSuccessStatusCode)
                        return await DeserializeJsonFromStream<List<WeatherForecastModel>>(stream, ".response[0].periods");

                    var content = await StreamToStringAsync(stream);
                    
                    throw new Exception(content);
                }
            }
            
        }
    }
}