using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using OpenWeatherMap.Client.Abstractions;
using OpenWeatherMap.Client.Factories;
using OpenWeatherMap.Client.Options;
using OpenWeatherMap.Client.Repositories;
using System.ComponentModel.DataAnnotations;
using System.Reflection;

namespace OpenWeatherMap.Client.Extensions
{
    public static class ContainerConfigurationExtension
    {
        //Configures the dependencies defined in the OpenWeatherMap.Client layer. 
        public static void AddApplicationLayer(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddOpenWeatherAPI(configuration);
            services.AddRepositories();
            services.AddValidators();
        }

        //Configure OpenWeatherMap API Key
        private static void AddOpenWeatherAPI(this IServiceCollection services, IConfiguration configuration)
        {
            var openWeatherConfig = configuration.GetSection("OpenWeatherOptions");
            services.Configure<OpenWeatherOptions>(openWeatherConfig);
            services.AddHttpClient();
        }

        private static void AddRepositories(this IServiceCollection services)
        {
            services.AddTransient<IOpenWeatherClient, OpenWeatherClient>();
            services.AddSingleton<IJsonSerializerSettingsFactory, JsonSerializerSettingsFactory>();
        }

        private static void AddValidators(this IServiceCollection services)
        {
            services.AddFluentValidationAutoValidation();
            services.AddFluentValidationClientsideAdapters();
            services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}
