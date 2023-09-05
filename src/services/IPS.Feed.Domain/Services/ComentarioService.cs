using IPS.Feed.Domain.Interfaces;
using IPS.Feed.Domain.Models;
using IPS.WebApi.Core.Usuario;

namespace IPS.Feed.Domain.Services
{
    public class ComentarioService : IComentarioService
    {

        private readonly IComentarioRepository _comentarioRepository;
        private readonly IAspNetUser _user;

        public ComentarioService(IComentarioRepository comentarioRepository, IAspNetUser user)
        {
            _comentarioRepository = comentarioRepository;
            _user = user;
        }

        public async Task Adicionar(Comentario obj)
        {
            //Instancia de um comentario
            obj.IdUsuario = _user.ObterUserId();

            //Verifica se tem erros

            //Verifica se a postagem existe
            
            //Adiciona ao banco
            await _comentarioRepository.Adicionar(obj);
        }

        public Task<bool> Remover(Guid idPostagem, Guid idComentario)
        {
            throw new NotImplementedException();
        }
    }
}
