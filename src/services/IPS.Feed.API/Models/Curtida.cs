using IPS.Core.DomainObjects;

namespace IPS.Feed.API.Models
{
    public class Curtida : Entity
    {
        public Guid IdUsuario { get; set; }
        public Guid IdPostagem { get; set; }
        public DateTime DataCurtida { get; set; }

        public Curtida(Guid idUsuario, Guid idPostagem)
        {
            IdUsuario = idUsuario;
            IdPostagem = idPostagem;
            DataCurtida = DateTime.Now;
        }


        //EF
        public Postagem Postagem { get; set; } = null!;
        protected Curtida() { }
    
    }
}
