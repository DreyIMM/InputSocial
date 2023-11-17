using IPS.Core.Messages;
using IPS.Feed.Domain.Interfaces;
using IPS.MessageBus;

namespace IPS.Feed.API.BackgroundTasks
{
    public class MessageNLPService : BackgroundService
    {

        private readonly IMessageBus _bus;
        private readonly IServiceProvider _serviceProvider;

        public MessageNLPService(IMessageBus bus, IServiceProvider serviceProvider)
        {
            _bus = bus;
            _serviceProvider = serviceProvider;
        }

        protected override Task ExecuteAsync(CancellationToken stoppingToken)
        {
            _bus.SubscribeAsync<ProcessarPostMensagemIntegrationEvent>("process_msg_nlp", message => ProcessMessage(message.Id, message.Mensagem));

            return Task.CompletedTask;
        }

        private async Task ProcessMessage(Guid id, string message)
        {

            using (var scoped = _serviceProvider.CreateScope())
            {
                var service = scoped.ServiceProvider.GetRequiredService<IUsuarioService>();

                await service.ProcessarMensagemNLP(id, message);
            }

        }
    }
}
