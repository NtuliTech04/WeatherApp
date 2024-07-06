using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Weather.DAL.Abstractions;
using Weather.DAL.Configurations.ValueObjects;
using Weather.DAL.Repositories;

namespace Weather.DAL.Extensions
{
    public static class ContainerConfigurationExtension
    {
        //Configures the dependencies defined in the DAL. 
        public static void RegisterDALDependencies(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddOpenWeatherAPI(configuration);
            services.AddRepositories();
        }
        
        //Configure OpenWeatherMap API Key
        private static void AddOpenWeatherAPI(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddHttpClient();
            services.Configure<OpenWeather>(configuration.GetSection("OpenWeather"));
        }

        private static void AddRepositories(this IServiceCollection services)
        {
            services.AddTransient<IOpenWeatherClient, OpenWeatherClient>();
        }
    }
}
