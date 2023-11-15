using IPS.Feed.Domain.Interfaces;
using IPS.Feed.Domain.Models;
using IPS.Feed.Domain.Services;
using IPS.WebApi.Core.Usuario;

namespace IPS.Feed.API.Services
{
    public class PostagemService : IPostagemService
    {
        private readonly IPostagemRepository _postagemRepository;
        private readonly IAspNetUser _user;

        public PostagemService(IPostagemRepository postagemRepository, IAspNetUser user)
        {
            _postagemRepository = postagemRepository;
            _user = user;
        }

        public async Task Adicionar(Postagem post)
        {
            //Instancia de Postagem
            post.IdUsuario = _user.ObterUserId();

            //verifica se tem erros via Fluent
            if(!post.EhValido()) return;

            //Adiciona no banco
            await _postagemRepository.Adicionar(post);
        }

        public async Task<bool> Remover(Guid id)
        {
            //Pega o ID do Usuario Logado
            Guid userLogado = _user.ObterUserId();
            
            //verificar se a postagem é do usuario
            var result = await _postagemRepository.PostagemUsuario(userLogado, id);
            
            if(!result) return false;

            //remover postagem
            await _postagemRepository.Remover(id);
            return true;
        }

        public async Task<List<Postagem>> PostagensUsuario()
        {
            return await _postagemRepository.PostagensUsuario(_user.ObterUserId());
        }

        public async Task<bool> AtualizarPost(Guid postId, string mensagem)
        {
            if(string.IsNullOrWhiteSpace(mensagem)) return false;

            //recuperar postagem
            Postagem post = await _postagemRepository.ObterPorId(postId);

            post.EntidadesNlp = mensagem;

            await _postagemRepository.Atualizar(post);

            return true;

        }
    }
}
