﻿using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Weather.DAL.Abstractions;
using Weather.DAL.Configurations;
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
            var openWeatherConfig = configuration.GetSection("OpenWeather");
            services.Configure<OpenWeather>(openWeatherConfig);
            services.AddHttpClient();

            //var moviesConfig = configuration.GetSection("OpenWeather").Get<OpenWeather>();
            //var WeatherAPIKey = configuration["OpenWeather:ApiKey"];
        }

        private static void AddRepositories(this IServiceCollection services)
        {
            services.AddTransient<IOpenWeatherClient, OpenWeatherClient>();
        }
    }
}
