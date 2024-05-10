using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;
using Weather.BLL.Services;
using Weather.BLL.Services.IService;
using Weather.DAL.Extensions;

namespace Weather.BLL.Extensions
{
    public static class ContainerConfigurationExtension
    {
        //Configures the dependencies defined in the BLL. 
        public static void RegisterBLLDependencies(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddAutoMapper();
            services.AddExternalServices(configuration);
            services.AddServices();
        }


        private static void AddAutoMapper(this IServiceCollection services)
        {
            //services.AddAutoMapper(typeof(AutoMapperProfile));
            services.AddAutoMapper(Assembly.GetExecutingAssembly());
        }

        private static void AddServices(this IServiceCollection services)
        {
            services.AddTransient<IWeatherService, WeatherService>();
        }

        //Registering Services defined in the DAL
        private static void AddExternalServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddHttpClient()
                .RegisterDALDependencies(configuration);
        }
    }
}
