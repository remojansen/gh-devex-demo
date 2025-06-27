using github_platform_demo_domain.Models;

namespace github_platform_demo_domain.Services
{
    public interface IWeatherService
    {
        Task<IEnumerable<WeatherForecast>> GetWeatherForecastAsync(string city);
        Task<IEnumerable<WeatherForecast>> GetHistoricalWeatherAsync(string city, int month);
        Task<WeatherForecast> CreateWeatherForecastAsync(WeatherForecast weatherForecast);
    }
}
