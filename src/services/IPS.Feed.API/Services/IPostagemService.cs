using IPS.Core.DomainObjects;
using IPS.Feed.API.DTO;
using IPS.Feed.API.Models;

namespace IPS.Feed.API.Services
{
    public interface IPostagemService
    {
        Task Adicionar(PostagemAddDTO post);
        Task<bool> Remover(Guid id);

    }
}
