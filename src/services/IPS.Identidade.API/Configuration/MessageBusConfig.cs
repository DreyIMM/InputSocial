using IPS.Core.Utils;
using IPS.MessageBus;
using IPS.Usuario.API.Services;

namespace IPS.Identidade.API.Configuration
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
