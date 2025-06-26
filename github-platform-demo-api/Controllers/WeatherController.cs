using Microsoft.AspNetCore.Mvc;
using github_platform_demo_domain.Services;
using github_platform_demo_domain.Models;


namespace github_platform_demo_api.Controllers
{

    interface IWeatherController
    {
        Task<IEnumerable<WeatherForecast>> GetWeatherForecastAsync(string city);
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

    }

}