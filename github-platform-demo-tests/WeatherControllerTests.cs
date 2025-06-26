using github_platform_demo_api.Controllers;
using github_platform_demo_tests.Mocks;

namespace github_platform_demo_tests
{
    public class WeatherControllerTests
    {
        [Fact]
        public async void GetWeatherForecastTest()
        {
            var logger = new Microsoft.Extensions.Logging.Abstractions.NullLogger<WeatherController>();
            var controller = new WeatherController(logger, new MockWeatherService());
            var result = await controller.GetWeatherForecastAsync("");
            Assert.NotNull(result);
            Assert.NotEmpty(result);
            Assert.Equal(2, result.Count());
            Assert.Equal(MockWeatherService.SampleForecasts[0].Summary, result.First().Summary);
            Assert.Equal(MockWeatherService.SampleForecasts[0].TemperatureC, result.First().TemperatureC);
            Assert.Equal(MockWeatherService.SampleForecasts[1].Summary, result.Last().Summary);
            Assert.Equal(MockWeatherService.SampleForecasts[1].TemperatureC, result.Last().TemperatureC);
        }


    }
}