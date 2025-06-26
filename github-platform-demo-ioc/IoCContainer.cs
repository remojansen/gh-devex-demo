using github_platform_demo_dal;
using github_platform_demo_domain.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace github_platform_demo_ioc
{
    public static class IoCContainer
    {
        public static void Initialize(WebApplicationBuilder builderInstance) {
            builderInstance.Services.AddTransient<IWeatherService, WeatherServiceImplementation>();
        }
    }
}
