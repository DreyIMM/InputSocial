using IPS.Feed.API.DTO;
using IPS.Feed.API.Models;

namespace IPS.Feed.API.Extensions
{
    public static class ComentarioExtensions
    {
        public static ComentarioDTO ToComentarioDTO(this Comentario comentario)
        {
            return new ComentarioDTO
            {
                Id              = comentario.Id,
                IdUsuario       = comentario.IdUsuario,
                IdPostagem      = comentario.IdPostagem,
                Mensagem        = comentario.Mensagem,
                DataComentario  = comentario.Data
            };
        }

        public static IEnumerable<ComentarioDTO> ToComentariosListDTO(this IEnumerable<Comentario> comentario)
        {
            return comentario.Select(c => c.ToComentarioDTO());
        }
    }
}

