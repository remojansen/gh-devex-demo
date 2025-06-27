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

        [Fact]
        public async void GetWeatherAlertsTest_ValidCity_ReturnsAlerts()
        {
            var logger = new Microsoft.Extensions.Logging.Abstractions.NullLogger<WeatherController>();
            var controller = new WeatherController(logger, new MockWeatherService());
            var result = await controller.GetWeatherAlertsAsync("TestCity");
            
            Assert.IsType<Microsoft.AspNetCore.Mvc.OkObjectResult>(result);
            var okResult = result as Microsoft.AspNetCore.Mvc.OkObjectResult;
            var alerts = okResult!.Value as IEnumerable<github_platform_demo_domain.Models.WeatherAlert>;
            
            Assert.NotNull(alerts);
            Assert.Equal(2, alerts.Count());
            Assert.All(alerts, alert => Assert.Equal("TestCity", alert.City));
        }

        [Fact]
        public async void GetWeatherAlertsTest_CityWithNoAlerts_ReturnsEmptyList()
        {
            var logger = new Microsoft.Extensions.Logging.Abstractions.NullLogger<WeatherController>();
            var controller = new WeatherController(logger, new MockWeatherService());
            var result = await controller.GetWeatherAlertsAsync("NonExistentCity");
            
            Assert.IsType<Microsoft.AspNetCore.Mvc.OkObjectResult>(result);
            var okResult = result as Microsoft.AspNetCore.Mvc.OkObjectResult;
            var alerts = okResult!.Value as IEnumerable<github_platform_demo_domain.Models.WeatherAlert>;
            
            Assert.NotNull(alerts);
            Assert.Empty(alerts);
        }

        [Fact]
        public async void GetWeatherAlertsTest_EmptyCity_ReturnsBadRequest()
        {
            var logger = new Microsoft.Extensions.Logging.Abstractions.NullLogger<WeatherController>();
            var controller = new WeatherController(logger, new MockWeatherService());
            var result = await controller.GetWeatherAlertsAsync("");
            
            Assert.IsType<Microsoft.AspNetCore.Mvc.BadRequestObjectResult>(result);
            var badRequestResult = result as Microsoft.AspNetCore.Mvc.BadRequestObjectResult;
            Assert.Equal("City parameter is required and cannot be empty.", badRequestResult!.Value);
        }

        [Fact]
        public async void GetWeatherAlertsTest_NullCity_ReturnsBadRequest()
        {
            var logger = new Microsoft.Extensions.Logging.Abstractions.NullLogger<WeatherController>();
            var controller = new WeatherController(logger, new MockWeatherService());
            var result = await controller.GetWeatherAlertsAsync(null!);
            
            Assert.IsType<Microsoft.AspNetCore.Mvc.BadRequestObjectResult>(result);
            var badRequestResult = result as Microsoft.AspNetCore.Mvc.BadRequestObjectResult;
            Assert.Equal("City parameter is required and cannot be empty.", badRequestResult!.Value);
        }


    }
}