using FluentValidation.Results;
using IPS.Core.DomainObjects;
using IPS.Usuario.API.Models;

namespace IPS.Usuario.API.Repository
{
    public interface IUsuarioRepository: IDisposable
    {
        Task<ValidationResult> Adicionar(UsuarioLogado usuario);

        Task<bool> ExisteCelular(string celular);

    }
}
