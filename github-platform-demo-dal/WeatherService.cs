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

        public async Task<WeatherForecast> CreateWeatherForecastAsync(WeatherForecast weatherForecast)
        {
            await Task.Delay(1000);
            using (var context = new WeatherContext())
            {
                context.WeatherForecast.Add(weatherForecast);
                await context.SaveChangesAsync();
            }
            return weatherForecast;
        }
    }
}
