using github_platform_demo_api.Controllers;
using github_platform_demo_tests.Mocks;

namespace github_platform_demo_tests
{
    public class WeatherControllerTests
    {
        [Fact]
        public async void GetWeatherForecastTest()
        {
            // Arrange
            var logger = new Microsoft.Extensions.Logging.Abstractions.NullLogger<WeatherController>();
            var mockWeatherService = new MockWeatherService();
            var controller = new WeatherController(logger, mockWeatherService);

            // Act
            var result = await controller.GetWeatherForecastAsync("test-city");

            // Assert
            Assert.NotNull(result);
            Assert.NotEmpty(result);
            Assert.Equal(2, result.Count());
            
            // Verify first item summary and temperature
            Assert.Equal(MockWeatherService.SampleForecasts[0].Summary, result.First().Summary);
            Assert.Equal(MockWeatherService.SampleForecasts[0].TemperatureC, result.First().TemperatureC);
            
            // Verify last item summary and temperature
            Assert.Equal(MockWeatherService.SampleForecasts[1].Summary, result.Last().Summary);
            Assert.Equal(MockWeatherService.SampleForecasts[1].TemperatureC, result.Last().TemperatureC);
        }

        [Fact]
        public async void GetHistoricalWeatherTest()
        {
            // Arrange
            var logger = new Microsoft.Extensions.Logging.Abstractions.NullLogger<WeatherController>();
            var mockWeatherService = new MockWeatherService();
            var controller = new WeatherController(logger, mockWeatherService);

            // Act
            var result = await controller.GetHistoricalWeatherAsync("test-city", 2);

            // Assert
            Assert.NotNull(result);
            Assert.NotEmpty(result);
            Assert.Equal(2, result.Count());
            
            // Verify first item summary and temperature
            Assert.Equal(MockWeatherService.SampleHistorical[0].Summary, result.First().Summary);
            Assert.Equal(MockWeatherService.SampleHistorical[0].TemperatureC, result.First().TemperatureC);
            
            // Verify last item summary and temperature
            Assert.Equal(MockWeatherService.SampleHistorical[1].Summary, result.Last().Summary);
            Assert.Equal(MockWeatherService.SampleHistorical[1].TemperatureC, result.Last().TemperatureC);
        }


    }
}