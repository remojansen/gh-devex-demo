using github_platform_demo_api.Controllers;
using github_platform_demo_domain.Models;
using github_platform_demo_domain.Services;

namespace github_platform_demo_tests.Mocks
{

    public class MockWeatherService : IWeatherService
    {
        public static readonly WeatherForecast[] SampleForecasts = new[]
        {
            new WeatherForecast
            {
                Date = DateOnly.FromDateTime(DateTime.Now),
                TemperatureC = 20,
                Summary = "Sunny"
            },
            new WeatherForecast
            {
                Date = DateOnly.FromDateTime(DateTime.Now.AddDays(1)),
                TemperatureC = 22,
                Summary = "Cloudy"
            }
        };

        public static readonly WeatherForecast[] SampleHistorical = new[]
        {
            new WeatherForecast
            {
                Date = DateOnly.FromDateTime(DateTime.Now.AddMonths(-1)),
                TemperatureC = 15,
                Summary = "Rainy"
            },
            new WeatherForecast
            {
                Date = DateOnly.FromDateTime(DateTime.Now.AddMonths(-1).AddDays(1)),
                TemperatureC = 18,
                Summary = "Windy"
            }
        };

        public Task<IEnumerable<WeatherForecast>> GetWeatherForecastAsync(string city)
        {
            return Task.FromResult<IEnumerable<WeatherForecast>>(new List<WeatherForecast>
            {
                SampleForecasts[0],
                SampleForecasts[1]
            });
        }
        public Task<IEnumerable<WeatherForecast>> GetHistoricalWeatherAsync(string city, int month)
        {
            return Task.FromResult<IEnumerable<WeatherForecast>>(new List<WeatherForecast>
            {
                SampleHistorical[0],
                SampleHistorical[1]
            });
        }
    }
}