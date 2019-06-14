using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace weatherappapi.Controllers
{
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
            var result = await weatherForecastRepository.GetCurrentWeather(city);
            return Ok(result);
        }

        // GET api/weather/forecast?city={city}
        [HttpGet ("forecast")]
        public async Task<ActionResult> GetForecast (string city) {
            var result = await weatherForecastRepository.GetWeatherForecast (city);

            return Ok(result);
        }
    }
}
