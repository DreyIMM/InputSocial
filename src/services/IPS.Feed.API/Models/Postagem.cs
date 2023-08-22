using IPS.Core.DomainObjects;

namespace IPS.Feed.API.Models
{
    public class Postagem: Entity
    {
        public Guid IdUsuario { get; set; }
        public DateTime DataPostagems { get; set; }
        public bool Modificado { get; set; }
        public string Mensagem { get; set; } = string.Empty;

        //EF
        public IEnumerable<Comentario> Comentarios { get; set; } = new List<Comentario>();
        public IEnumerable<Curtida> Curtidas { get; set; } = new List<Curtida>();
        protected Postagem(){}

        public Postagem(Guid idUsuario, bool modificado, string mensagem)
        {
            IdUsuario = idUsuario;
            DataPostagems = DateTime.Now;
            Modificado = modificado;
            Mensagem = mensagem;
        }



    }
}
