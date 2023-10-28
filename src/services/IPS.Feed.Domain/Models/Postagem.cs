using IPS.Core.DomainObjects;
using IPS.Feed.Domain.Models.Validations;

namespace IPS.Feed.Domain.Models
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
        public Postagem(){}

        public Postagem(Guid idUsuario, bool modificado, string mensagem)
        {
            IdUsuario = idUsuario;
            Modificado = modificado;
            Mensagem = mensagem;
        }

        public Postagem(bool modificado, string mensagem)
        {
            Modificado = modificado;
            Mensagem = mensagem;
            DataPostagems = DateTime.Now;
        }

        internal bool EhValido()
        {
            return new PostagemValidation().Validate(this).IsValid;
        }


    }
}
