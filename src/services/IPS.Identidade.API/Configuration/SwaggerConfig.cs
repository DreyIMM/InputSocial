using Microsoft.OpenApi.Models;

namespace IPS.Identidade.API.Configuration
{
    public static class SwaggerConfig
    {
        public static IServiceCollection AddSwaggerConfig(this IServiceCollection services)
        {

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "Input Social Autenticador ",
                    Description = "Api de autenticação do aplicativo Input Social",
                    Contact = new OpenApiContact() { Name = "IPS", Email = "ips@devq.com.br" },
                    License = new OpenApiLicense() { Name = "MIT", Url = new Uri("https://opensource.org/licenses/MIT") }
                });
            });

            return services;
        }


        public static IApplicationBuilder UseSwaggerConfig(this IApplicationBuilder app)
        {

            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "v1");
            });

            return app;
        }


    }
}
