using Microsoft.Extensions.DependencyInjection;
using NUnit.Framework;
using System.Threading.Tasks;
using weatherappapi;

namespace Tests
{
    public class Tests
    {
        private readonly IWeatherForecastRepository weatherForecastRepository;
        public Tests(IWeatherForecastRepository weatherForecastRepository)
        {
            this.weatherForecastRepository = weatherForecastRepository;
        }

        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public async Task Test1()
        {
            var weather = await weatherForecastRepository.GetCurrentWeather("Hamburg");
            Assert.IsNotNull(weather);
            Assert.IsNotEmpty(weather.WeatherEvent);
        }
    }
}