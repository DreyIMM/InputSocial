using IPS.Feed.API.Data;
using IPS.WebApi.Core.Identidade;
using Microsoft.EntityFrameworkCore;
using System.Text.Json.Serialization;
using System.Text.Json;

namespace IPS.Feed.API.Configuration
{
    public static class ApiConfig
    {

        public static IServiceCollection AddApiConfiguration(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<FeedContext>(options =>
              options.UseNpgsql(configuration.GetConnectionString("DefaultConnection")));

            services.AddControllers()
             .AddJsonOptions(options =>
             {
                 options.JsonSerializerOptions.PropertyNamingPolicy = JsonNamingPolicy.CamelCase;
                 options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
             });

            return services;
        }


        public static IApplicationBuilder UseApiConfiguration(this IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthConfiguration();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });


            return app;
        }

    }
}
