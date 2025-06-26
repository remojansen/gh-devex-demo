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

        public Task<IEnumerable<WeatherAlert>> GetWeatherAlertsAsync(string city)
        {
            return Task.FromResult<IEnumerable<WeatherAlert>>(GetSampleAlertsForCity(city));
        }

        public static readonly WeatherAlert[] SampleAlerts = new[]
        {
            new WeatherAlert
            {
                Id = 1,
                City = "TestCity",
                AlertType = "Heat Warning",
                Description = "Test heat warning",
                Severity = "High",
                StartTime = DateTime.Now.AddHours(1),
                EndTime = DateTime.Now.AddHours(6)
            },
            new WeatherAlert
            {
                Id = 2,
                City = "TestCity",
                AlertType = "Storm Warning",
                Description = "Test storm warning",
                Severity = "Medium",
                StartTime = DateTime.Now.AddHours(2),
                EndTime = DateTime.Now.AddHours(8)
            },
            new WeatherAlert
            {
                Id = 3,
                City = "EmptyCity",
                AlertType = "Wind Warning",
                Description = "Test wind warning",
                Severity = "Low",
                StartTime = DateTime.Now.AddHours(3),
                EndTime = DateTime.Now.AddHours(9)
            }
        };

        private static List<WeatherAlert> GetSampleAlertsForCity(string city)
        {
            if (string.IsNullOrWhiteSpace(city))
            {
                return new List<WeatherAlert>();
            }

            return SampleAlerts.Where(alert => 
                string.Equals(alert.City, city, StringComparison.OrdinalIgnoreCase))
                .ToList();
        }
    }
}