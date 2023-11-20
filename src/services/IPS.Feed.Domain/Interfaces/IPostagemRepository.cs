using IPS.Feed.Domain.Models;

namespace IPS.Feed.Domain.Interfaces
{
    public interface IPostagemRepository : IRepository<Postagem>
    {
        Task<List<Postagem>> ObterTodasPostagem(); 
        Task<Postagem> ObterDetalhePostagem(Guid Idpostagem);
        Task<bool> PostagemUsuario(Guid IdUser, Guid IdPostagem);
        Task<List<Postagem>> PostagensUsuario(Guid IdUser);
        Task<List<string>> ObterPostagensMoments();
    }
}
