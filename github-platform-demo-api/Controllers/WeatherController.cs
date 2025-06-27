using Microsoft.AspNetCore.Mvc;
using github_platform_demo_domain.Services;
using github_platform_demo_domain.Models;


namespace github_platform_demo_api.Controllers
{

    interface IWeatherController
    {
        Task<IEnumerable<WeatherForecast>> GetWeatherForecastAsync(string city);
        Task<IActionResult> GetWeatherAlertsAsync(string city);
    }

    [ApiController]
    [Route("[controller]")]
    public class WeatherController : ControllerBase, IWeatherController
    {
        private readonly ILogger<WeatherController> _logger;
        private readonly IWeatherService weatherService;

        public WeatherController(
            ILogger<WeatherController> logger,
            IWeatherService weatherService
        )
        {
            _logger = logger;
            this.weatherService = weatherService;
        }

        [HttpGet("Forecast", Name = "GetWeatherForecast")]
        public async Task<IEnumerable<WeatherForecast>> GetWeatherForecastAsync([FromQuery] string city)
        {   
            return await weatherService.GetWeatherForecastAsync(city);
        }

        [HttpGet("Alerts", Name = "GetWeatherAlerts")]
        public async Task<IActionResult> GetWeatherAlertsAsync([FromQuery] string city)
        {
            if (string.IsNullOrWhiteSpace(city))
            {
                return BadRequest("City parameter is required and cannot be empty.");
            }

            try
            {
                var alerts = await weatherService.GetWeatherAlertsAsync(city);
                return Ok(alerts);
            }
            catch (Exception)
            {
                return StatusCode(500, "An error occurred while retrieving weather alerts.");
            }
        }

    }

}