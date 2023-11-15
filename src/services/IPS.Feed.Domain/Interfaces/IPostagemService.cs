using IPS.Feed.Domain.Models;

namespace IPS.Feed.Domain.Services
{
    public interface IPostagemService
    {
        Task Adicionar(Postagem post);
        Task<bool> Remover(Guid id);
        Task<List<Postagem>> PostagensUsuario();
        Task<bool> AtualizarPost(Guid idPost, string mensagem);
    }
}
