using IPS.Usuario.API.Data;
using IPS.Usuario.API.Repository;
using IPS.Usuario.API.Services;
using IPS.MessageBus;
using IPS.Core.Utils;

namespace IPS.Usuario.API.Configuration
{
    public static class DependencyInjectionConfig
    {
        public static void RegisterServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<UsuarioContext>();
            services.AddScoped<IUsuarioRepository, UsuarioRepository>();
            services.AddMessageBus(configuration.GetMessageQueueConnection("MessageBus"))
                           .AddHostedService<UsuarioService>();
        }
    }
}
