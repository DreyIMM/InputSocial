using IPS.Core.Messages;
using IPS.Usuario.API.Models;

namespace IPS.Usuario.API.Services
{
    public interface IUsuarioService
    {
        Task<ResponseMessage> Adicionar(UsuarioRegistradoIntegrationEvent usuario);
    }

}
