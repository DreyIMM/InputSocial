using IPS.Core.DomainObjects;
using IPS.Feed.Domain.Models.Validations;
using System.ComponentModel.DataAnnotations.Schema;

namespace IPS.Feed.Domain.Models
{
    public class Postagem: Entity
    {
        public Guid IdUsuario { get; set; }

        [Column(TypeName = "timestamp without time zone")]
        public DateTime DataPostagems { get; set; } 
        public bool Modificado { get; set; }
        public string Mensagem { get; set; } = string.Empty;
        [NotMapped]
        public string NomeUsuario { get; set; } = string.Empty;
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public string Bairro { get; set; }
        public string Regiao { get; set; }
        public string? EntidadesNlp { get; set; }

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

        public Postagem(bool modificado, string mensagem, double lat, double longit, string bairro, string regiao)
        {
            Modificado = modificado;
            Mensagem = mensagem;
            DataPostagems = DateTime.Now;
            Latitude = lat;
            Longitude = longit;
            Bairro = bairro;
            Regiao = regiao;
        }

        internal bool EhValido()
        {
            return new PostagemValidation().Validate(this).IsValid;
        }


    }
}
