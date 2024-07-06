using FluentValidation.AspNetCore;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Versioning;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;
using Weather.BLL.Abstractions;
using Weather.BLL.Abstractions.Repositories;
using Weather.BLL.Services;
using Weather.BLL.Services.IService;
using Weather.BLL.Utilities.Swagger;

namespace Weather.BLL.Extensions
{
    public static class ContainerConfigurationExtension
    {
        //Configures the dependencies defined in the BLL. 
        public static void RegisterBLLDependencies(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddAutoMapper();
            services.AddRepositories();
            services.AddServices();
            services.AddValidators();
            services.APIVersioning();
            services.AddVersionedAPI();
            services.AddSwaggerSupport();
            services.ConfigureOptions<SwaggerConfigurationOptions>();
        }


        private static void AddAutoMapper(this IServiceCollection services)
        {
            //services.AddAutoMapper(typeof(AutoMapperProfile));
            services.AddAutoMapper(Assembly.GetExecutingAssembly());
        }

        public static void AddRepositories(this IServiceCollection services)
        {
            services.AddTransient<ICustomWeatherRepository, CustomWeatherRepository>();
        }

        private static void AddServices(this IServiceCollection services)
        {
            services.AddTransient<IDateTimeService, DateTimeService>();
            services.AddTransient<IWeatherForecastService, WeatherForecastService>();
            services.AddTransient<ICustomWeatherService, CustomWeatherService>();
        }

        private static void AddValidators(this IServiceCollection services)
        {
            services.AddFluentValidationAutoValidation();
            services.AddFluentValidationClientsideAdapters();
            services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
        }


        #region API Versioning

        // API Versioning Configuration
        private static void APIVersioning(this IServiceCollection services)
        {
            services.AddApiVersioning(opt =>
            {
                opt.ReportApiVersions = true;
                opt.DefaultApiVersion = new ApiVersion(1, 0);
                opt.ApiVersionReader = new UrlSegmentApiVersionReader();
                opt.AssumeDefaultVersionWhenUnspecified = true;
            });
        }

        private static void AddVersionedAPI(this IServiceCollection services)
        {
            services.AddVersionedApiExplorer(setup =>
            {
                setup.GroupNameFormat = "'v'VVV";
                setup.SubstituteApiVersionInUrl = true;
            });
        }

        #endregion


        #region  Swagger API Support

        private static void AddSwaggerSupport(this IServiceCollection services)
        {
            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen();

            //services.AddSwaggerGen(options =>
            //{
            //    var jwtSecurityScheme = new OpenApiSecurityScheme
            //    {
            //        Description = "Paste your JWT Bearer token",
            //        In = ParameterLocation.Header,
            //        Name = "JWT Authentication",
            //        Scheme = "Bearer",
            //        BearerFormat = "JWT",
            //        Type = SecuritySchemeType.Http,

            //        Reference = new OpenApiReference
            //        {
            //            Id = JwtBearerDefaults.AuthenticationScheme,
            //            Type = ReferenceType.SecurityScheme
            //        }
            //    };

            //    options.AddSecurityDefinition(jwtSecurityScheme.Reference.Id, jwtSecurityScheme);

            //    options.AddSecurityRequirement(new OpenApiSecurityRequirement
            //    {
            //        {
            //            jwtSecurityScheme, Array.Empty<string>()
            //        }
            //    });
            //});
        }

        // JWT Authentication is not implemented.
        // Configure it here when needed.
        // Check NetChill Movies App for guidance

        #endregion
    }
}
