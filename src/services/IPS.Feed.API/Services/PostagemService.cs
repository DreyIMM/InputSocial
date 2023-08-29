using IPS.Feed.API.DTO;
using IPS.Feed.API.Interfaces;
using IPS.Feed.API.Models;
using System.ComponentModel;

namespace IPS.Feed.API.Services
{
    public class PostagemService : IPostagemService
    {
        private readonly IPostagemRepository _postagemRepository;
        public PostagemService(IPostagemRepository postagemRepository)
        {
            _postagemRepository = postagemRepository;
        }

        public async Task Adicionar(PostagemAddDTO dto)
        {

            //Instancia de Postagem
            Guid idUser = Guid.Parse("7ab0bdd2-b38a-44ec-bcd3-85b75780d4a5");
            Postagem post = new Postagem(idUser, dto.Modificado, dto.Mensagem);

            //verifica se tem erros via Fluent
            if(!post.EhValido()) return;

            //Adiciona no banco
            await _postagemRepository.Adicionar(post);

        }
    }
}
