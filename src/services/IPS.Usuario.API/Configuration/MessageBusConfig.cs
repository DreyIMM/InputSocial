using IPS.MessageBus;
using IPS.Usuario.API.Services;
using IPS.Core.Utils;
using System.Diagnostics;

namespace IPS.Usuario.API.Configuration
{
    public static class MessageBusConfig
    {
        public static void AddMessageBusConfiguration(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddMessageBus(configuration.GetMessageQueueConnection("MessageBus"))
                .AddHostedService<UsuarioService>();
        }
    }
}