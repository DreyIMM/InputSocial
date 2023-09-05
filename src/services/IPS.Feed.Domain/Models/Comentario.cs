using IPS.Core.DomainObjects;

namespace IPS.Feed.Domain.Models
{
    public class Comentario : Entity
    {
        public Guid IdUsuario { get; set; }
        public Guid IdPostagem { get; set; }
        public string Mensagem { get; set; } = string.Empty;
        public DateTime Data { get; set; }

        public Comentario(Guid idPostagem, string mensagem)
        {
            IdPostagem = idPostagem;
            Mensagem = mensagem;
            Data = DateTime.Now.ToUniversalTime(); ;
        }


        //EF
        public Comentario() { }
        public Postagem Postagem { get; set; } = null!;


    }
}
