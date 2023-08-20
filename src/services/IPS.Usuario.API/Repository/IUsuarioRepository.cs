using IPS.Core.DomainObjects;
using IPS.Usuario.API.Models;

namespace IPS.Usuario.API.Repository
{
    public interface IUsuarioRepository: IDisposable
    {
        Task Adicionar(UsuarioLogado usuario);


    }
}
