using Serilog;
using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Weather.API.Extensions;
using Weather.BLL.Extensions;
using Weather.DAL.Extensions;

namespace Weather.API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            
            // Register Layers Dependencies
            builder.Services.RegisterDALDependencies(builder.Configuration);
            builder.Services.RegisterBLLDependencies(builder.Configuration);
            builder.Services.RegisterPLDependencies(builder.Configuration);
            
            // Configure Serilog logging 
            builder.Host.UseSerilog((context, configuration) =>
            configuration.ReadFrom.Configuration(context.Configuration));

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI(options =>
                {
                    var provider = app.Services.GetRequiredService<IApiVersionDescriptionProvider>();

                    foreach (var description in provider.ApiVersionDescriptions)
                    {
                        options.SwaggerEndpoint($"../swagger/{description.GroupName}/swagger.json", description.GroupName.ToString());
                    }
                    //Turns off syntax highlight which causing performance issues...
                    options.ConfigObject.AdditionalItems.Add("syntaxHighlight", false);
                    //Reverts Swagger UI 2.x  theme which is simpler not much performance benefit...
                    options.ConfigObject.AdditionalItems.Add("theme", "agate");
                });
            }

            app.UseSerilogRequestLogging();
            app.UseHttpsRedirection();
            app.UseRouting();

            //Configures client app access by whitelisting its URL
            app.UseCors("CorsPolicy");

            app.UseAuthorization();

            app.MapControllers();

            app.Run();
        }
    }
}
