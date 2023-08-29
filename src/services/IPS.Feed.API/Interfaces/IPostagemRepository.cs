using IPS.Core.DomainObjects;
using IPS.Feed.API.Models;

namespace IPS.Feed.API.Interfaces
{
    public interface IPostagemRepository : IRepository<Postagem>
    {
        Task<List<Postagem>> ObterTodasPostagem(); 
        Task<Postagem> ObterDetalhePostagem(Guid Idpostagem);
    }
}
