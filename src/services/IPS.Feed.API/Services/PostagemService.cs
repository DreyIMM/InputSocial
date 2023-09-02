using IPS.Feed.API.DTO;
using IPS.Feed.API.Interfaces;
using IPS.Feed.API.Models;
using IPS.WebApi.Core.Usuario;
using System.ComponentModel;

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

        public async Task Adicionar(PostagemAddDTO dto)
        {

            //Instancia de Postagem
            Postagem post = new Postagem(_user.ObterUserId(), dto.Modificado, dto.Mensagem);

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
    }
}
