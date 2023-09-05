using IPS.Core.DomainObjects;

namespace IPS.Feed.Domain.Models
{
    public class Comentario : Entity
    {
        public Guid IdUsuario { get; set; }
        public Guid IdPostagem { get; set; }
        public string Mensagem { get; set; } = string.Empty;
        public DateTime Data { get; set; }

        public Comentario(Guid idUsuario, Guid idPostagem, string mensagem)
        {
            IdUsuario = idUsuario;
            IdPostagem = idPostagem;
            Mensagem = mensagem;
            Data = DateTime.Now;
        }


        //EF
        protected Comentario() { }
        public Postagem Postagem { get; set; } = null!;


    }
}
