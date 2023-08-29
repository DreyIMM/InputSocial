using IPS.Feed.API.Data;
using IPS.Feed.API.Interfaces;
using IPS.Feed.API.Repository;
using IPS.Feed.API.Services;
using System.Collections.Generic;

namespace IPS.Feed.API.Configuration
{
    public static class DependencyInjectionConfig
    {
        public static IServiceCollection RegisterServices(this IServiceCollection services)
        {
            services.AddScoped<FeedContext>();
            services.AddScoped<IPostagemRepository, PostagemRepository>();
            services.AddScoped<IPostagemService, PostagemService>();

           

            return services;
        }
    }
}
