using System.Web.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using weatherappapi.models;
using System.Net.Http;

namespace weatherappapi.Controllers {
    [Route ("api/[controller]")]
    [ApiController]
    public class WeatherController : ControllerBase {
        private readonly IWeatherForecastRepository weatherForecastRepository;

        public WeatherController (IWeatherForecastRepository weatherForecastRepository) {
            this.weatherForecastRepository = weatherForecastRepository;
        }

        // GET api/weather/current?city={city}
        [HttpGet ("current")]
        public async Task<ActionResult> GetCurrent (string city) {
            var result = await weatherForecastRepository.GetCurrentWeather (city);

            return Ok (new {
                result.Response.Ob.Humidity,
                    result.Response.Ob.TempC,
                    result.Response.Ob.Weather,
                    result.Response.Ob.WindSpeedKph
            });
        }

        // GET api/weather/forecast?city={city}
        [HttpGet ("forecast")]
        public async Task<ActionResult> GetForecast (string city) {
            var result = await weatherForecastRepository.GetWeatherForecast (city);

            return  Ok(result.Response.FirstOrDefault ().Periods.Select (s => new {
                s.DateTimeIso,
                    s.MaxHumidity,
                    s.MaxTempC,
                    s.MinHumidity,
                    s.MinTempC,
                    s.Weather,
                    s.WindSpeedMaxKph,
                    s.WindSpeedMinKph
            }));
        }
    }
}