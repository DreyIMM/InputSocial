using IPS.Feed.API.DTO;
using IPS.Feed.Domain.Models;

namespace IPS.Feed.API.Extensions
{
    public static class PostagemExtensions
    {
        #region Entity Return DTO - Extensions

        public static PostagensDTO ToPostDTO(this Postagem postagem)
        {
            return new PostagensDTO
            {
                Id              = postagem.Id,
                IdUsuario       = postagem.IdUsuario,
                DataPostagem    = postagem.DataPostagems,
                Modificado      = postagem.Modificado,
                Mensagem        = postagem.Mensagem,
                TotalCurtidas   = postagem.Curtidas.Count(),
                NomeUsuario     = postagem.NomeUsuario,
                Regiao          = postagem.Regiao,
                Bairro          = postagem.Bairro
            };
        }

        public static PostagemDTO ToUniquePostDTO(this Postagem postagem)
        {
            return new PostagemDTO
            {
                Id              = postagem.Id,
                IdUsuario       = postagem.IdUsuario,
                DataPostagem    = postagem.DataPostagems,
                Modificado      = postagem.Modificado,
                Mensagem        = postagem.Mensagem,
                TotalCurtidas   = postagem.Curtidas.Count(),
                Comentarios     = postagem.Comentarios.ToComentariosListDTO(),
            };
        }
        
        public static IEnumerable<PostagensDTO> ToPostListDTO(this List<Postagem> postagem)
        {
            return postagem.Select(postagem => postagem.ToPostDTO());
        }

        #endregion


    }
}
