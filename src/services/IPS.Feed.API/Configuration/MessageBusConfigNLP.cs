using IPS.Core.Utils;
using IPS.MessageBus;
using IPS.Feed.API.BackgroundTasks;

namespace IPS.Feed.API.Configuration
{    
    public static class MessageBusConfigNLP
    {
        public static void AddMessageBusConfigurationNLP(this IServiceCollection services,
            IConfiguration configuration)
        {
            services.AddMessageBus(configuration.GetMessageQueueConnection("MessageBus"))
            .AddHostedService<MessageNLPService>();
        }
    }
}
