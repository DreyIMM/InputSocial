using FluentValidation.Results;
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
            var stream = new MemoryStream(user.FotoPerfil);
            var usuario = new UsuarioLogado(user.Id, user.UserName, user.Celular, user.DataAniversario, stream, user.ExtensionFile);

            ValidationResult sucesso;
            using (var scoped = _serviceProvider.CreateScope())
            {
                var service = scoped.ServiceProvider.GetRequiredService<IUsuarioRepository>();
                
                sucesso = await service.Adicionar(usuario);
            }

            return new ResponseMessage(sucesso);
        }

    }

}
