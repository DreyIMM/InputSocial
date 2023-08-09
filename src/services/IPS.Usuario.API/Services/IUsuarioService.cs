using IPS.Usuario.API.Models;

namespace IPS.Usuario.API.Services
{
    public interface IUsuarioService
    {
        Task Adicionar(UsuarioLogado usuario);
    }

}
