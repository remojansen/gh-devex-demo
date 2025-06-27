using github_platform_demo_domain.Models;
using System.Data.Entity;

namespace github_platform_demo_dal
{
    public class WeatherContext : DbContext
    {
        public DbSet<WeatherForecast> WeatherForecast { get; set; }
    }
}