using github_platform_demo_domain.Models;
using github_platform_demo_domain.Services;

namespace github_platform_demo_dal
{
    public class WeatherServiceImplementation : IWeatherService
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        public async Task<IEnumerable<WeatherForecast>> GetHistoricalWeatherAsync(string city, int month)
        {
            await Task.Delay(1000); // Simulate async work
            // Generate mock data instead of fetching from a database for demonstration purposes
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
                TemperatureC = Random.Shared.Next(-20, 55),
                Summary = Summaries[Random.Shared.Next(Summaries.Length)]
            })
            .ToArray();
        }

        public async Task<IEnumerable<WeatherForecast>> GetWeatherForecastAsync(string city)
        {
            await Task.Delay(1000);
            // Generate mock data instead of fetching from a database for demonstration purposes
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
                TemperatureC = Random.Shared.Next(-20, 55),
                Summary = Summaries[Random.Shared.Next(Summaries.Length)]
            })
            .ToArray();
        }

        public async Task<IEnumerable<WeatherAlert>> GetWeatherAlertsAsync(string city)
        {
            await Task.Delay(500); // Simulate async work
            
            // Return hardcoded weather alerts based on city
            var allAlerts = GetHardcodedWeatherAlerts();
            
            if (string.IsNullOrWhiteSpace(city))
            {
                return new List<WeatherAlert>();
            }
            
            return allAlerts.Where(alert => 
                string.Equals(alert.City, city, StringComparison.OrdinalIgnoreCase))
                .ToArray();
        }

        private static List<WeatherAlert> GetHardcodedWeatherAlerts()
        {
            return new List<WeatherAlert>
            {
                new WeatherAlert
                {
                    Id = 1,
                    City = "Seville",
                    AlertType = "Heat Warning",
                    Description = "Extreme heat expected with temperatures above 40°C",
                    Severity = "High",
                    StartTime = DateTime.Now.AddHours(2),
                    EndTime = DateTime.Now.AddDays(2)
                },
                new WeatherAlert
                {
                    Id = 2,
                    City = "Madrid",
                    AlertType = "Thunderstorm Warning",
                    Description = "Severe thunderstorms with heavy rain and strong winds",
                    Severity = "Medium",
                    StartTime = DateTime.Now.AddHours(6),
                    EndTime = DateTime.Now.AddHours(18)
                },
                new WeatherAlert
                {
                    Id = 3,
                    City = "Barcelona",
                    AlertType = "Flood Warning",
                    Description = "Heavy rainfall may cause flooding in low-lying areas",
                    Severity = "High",
                    StartTime = DateTime.Now.AddHours(1),
                    EndTime = DateTime.Now.AddHours(12)
                },
                new WeatherAlert
                {
                    Id = 4,
                    City = "Seville",
                    AlertType = "UV Warning",
                    Description = "Very high UV index expected, take sun protection measures",
                    Severity = "Low",
                    StartTime = DateTime.Now.AddDays(1),
                    EndTime = DateTime.Now.AddDays(1).AddHours(8)
                }
            };
        }
    }
}
