using IPS.Feed.API.DTO;
using IPS.Feed.Domain.Models;

namespace IPS.Feed.API.Extensions
{
    public static class ComentarioExtensions
    {
        public static ComentarioAddDTO ToComentarioAddDTO(this Comentario comentario)
        {
            return new ComentarioAddDTO
            {
                IdUsuario       = comentario.IdUsuario,
                Mensagem        = comentario.Mensagem,
            };
        }

        public static ComentarioViewDTO ToComentarioView(this Comentario comentario)
        {
            return new ComentarioViewDTO
            {
                IdUsuario = comentario.IdUsuario,
                Mensagem = comentario.Mensagem,
                NomeUsuarioComentario = comentario.NomeUsuario,
            };
        }

        public static IEnumerable<ComentarioViewDTO> ToComentariosListDTO(this IEnumerable<Comentario> comentario)
        {
            return comentario.Select(c => c.ToComentarioView());
        }
    }
}

