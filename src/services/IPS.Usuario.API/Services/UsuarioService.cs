using IPS.Core.Messages;
using IPS.MessageBus;
using IPS.Usuario.API.Models;
using IPS.Usuario.API.Repository;

namespace IPS.Usuario.API.Services
{
    public class  UsuarioService: BackgroundService
    {
        private readonly IMessageBus _bus;
        private readonly IServiceProvider _serviceProvider;

        public UsuarioService(IMessageBus bus, IServiceProvider serviceProvider)
        {
            _bus = bus;
            _serviceProvider = serviceProvider;
        }

        protected override Task ExecuteAsync(CancellationToken stoppingToken)
        {
            _bus.RespondAsync<UsuarioRegistradoIntegrationEvent, ResponseMessage>(async request =>
               await RegistrarUsuario(request));

            return Task.CompletedTask;
        }


        private async Task<ResponseMessage> RegistrarUsuario(UsuarioRegistradoIntegrationEvent user)
        {
            var usuario = new UsuarioLogado(user.Id, user.UserName, user.Celular, user.DataAniversario);

            if (!usuario.EhValido()) return new ResponseMessage(false);

            using (var scoped = _serviceProvider.CreateScope())
            {
                var service = scoped.ServiceProvider.GetRequiredService<IUsuarioRepository>();

                await service.Adicionar(usuario);

            }

            return new ResponseMessage(true);
        }

    }

}
