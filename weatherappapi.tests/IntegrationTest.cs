using Microsoft.AspNetCore.Mvc.Testing;
using System.Net.Http;
using System.Threading.Tasks;
using weatherappapi;
using weatherappapi.models;
using Xunit;

namespace Tests
{
    public class IntegrationTest : IClassFixture<WebApplicationFactory<Startup>>
    {
        private readonly WebApplicationFactory<Startup> _factory;

        public IntegrationTest(WebApplicationFactory<Startup> factory)
        {
            _factory = factory;
        }

        [Theory]
        [InlineData("dresden")]
        [InlineData("hamburg")]
        public async Task Get_CurrentWeatherShouldResultMeaningfulWhenACorrectCityIsSupplied(string city)
        {
            using var h = _factory.CreateClient();
            var weatherApiResult = await h.GetAsync($"/weather/current?city={city}");
            Assert.NotNull(weatherApiResult.Content);
            var currentWeatherResponse = await weatherApiResult.Content.ReadAsAsync<CurrentWeatherModel>();
            Assert.NotNull(currentWeatherResponse);
            Assert.NotEmpty(currentWeatherResponse.WeatherEvent);
        }
    }
}