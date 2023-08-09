using IPS.Usuario.API.Data;
using IPS.Usuario.API.Repository;
using IPS.Usuario.API.Services;

namespace IPS.Usuario.API.Configuration
{
    public static class DependencyInjectionConfig
    {
        public static void RegisterServices(this IServiceCollection services)
        {
            services.AddScoped<UsuarioContext>();
            services.AddScoped<IUsuarioRepository, UsuarioRepository>();
            services.AddScoped<IUsuarioService, UsuarioService>();
        }
    }
}
