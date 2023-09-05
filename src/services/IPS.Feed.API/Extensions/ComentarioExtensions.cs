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

        public static IEnumerable<ComentarioAddDTO> ToComentariosListDTO(this IEnumerable<Comentario> comentario)
        {
            return comentario.Select(c => c.ToComentarioAddDTO());
        }
    }
}

