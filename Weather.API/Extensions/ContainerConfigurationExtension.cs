using Serilog;

namespace Weather.API.Extensions
{
    public static class ContainerConfigurationExtension
    {
        public static void RegisterPLDependencies(this IServiceCollection services, IConfiguration configuration)
        {
            services.CorsPolicy();
            services.Controllers();
        }


        //Configures client app access by whitelisting its URL
        public static void CorsPolicy(this IServiceCollection services)
        {
            services.AddCors(options =>
            {
                options.AddPolicy("CorsPolicy",
                    policy => policy
                        .WithOrigins("http://localhost:4200")
                        .AllowAnyMethod()
                        .AllowAnyHeader());
            });
        }

        //Configure Controllers with options
        public static void Controllers(this IServiceCollection services)
        {
            services.AddControllers().AddNewtonsoftJson()
                .AddJsonOptions(options =>
                {
                    options.JsonSerializerOptions
                        .DefaultIgnoreCondition = System.Text.Json.Serialization
                        .JsonIgnoreCondition.WhenWritingNull;
                });
        }
    }
}
