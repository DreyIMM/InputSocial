using IPS.Core.DomainObjects;
using System.ComponentModel.DataAnnotations.Schema;

namespace IPS.Feed.Domain.Models
{
    public class Comentario : Entity
    {
        public Guid IdUsuario { get; set; }
        public Guid IdPostagem { get; set; }
        public string Mensagem { get; set; } = string.Empty;

        [Column(TypeName = "timestamp without time zone")]
        public DateTime Data { get; set; }

        [NotMapped]
        public string NomeUsuario { get; set; } = string.Empty;

        public Comentario(Guid idPostagem, string mensagem)
        {
            IdPostagem = idPostagem;
            Mensagem = mensagem;
            Data = DateTime.Now;
        }


        //EF
        public Comentario() { }
        public Postagem Postagem { get; set; } = null!;


    }
}
