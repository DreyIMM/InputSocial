using IPS.Feed.API.Services;
using IPS.Feed.Domain.Interfaces;
using IPS.Feed.Domain.Services;
using IPS.Feed.Infa.Repository;
using IPS.Feed.Infra.Data;
using IPS.Feed.Infra.Repository;
using IPS.WebApi.Core.Usuario;

namespace IPS.Feed.API.Configuration
{
    public static class DependencyInjectionConfig
    {
        public static IServiceCollection RegisterServices(this IServiceCollection services)
        {
            services.AddScoped<FeedContext>();
            services.AddScoped<IPostagemRepository, PostagemRepository>();
            services.AddScoped<IPostagemService, PostagemService>();
            services.AddScoped<IComentarioRepository, ComentarioRepository>();
            services.AddScoped<IComentarioService, ComentarioService>();
            services.AddScoped<ICurtidaRepository, CurtidaRepository>();
            services.AddScoped<ICurtidaService, CurtidaService>();
            services.AddHttpClient<IUsuarioService, UsuarioService>();

            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddScoped<IAspNetUser, AspNetUser>();

            return services;
        }
    }
}
