using IPS.Feed.API.Data;
using IPS.WebApi.Core.Identidade;
using Microsoft.EntityFrameworkCore;
using System.Text.Json.Serialization;

namespace IPS.Feed.API.Configuration
{
    public static class ApiConfig
    {

        public static IServiceCollection AddApiConfiguration(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<FeedContext>(options =>
              options.UseNpgsql(configuration.GetConnectionString("DefaultConnection")));

            services.AddControllers()
                .AddJsonOptions(o => o.JsonSerializerOptions
                 .ReferenceHandler = ReferenceHandler.Preserve);

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
