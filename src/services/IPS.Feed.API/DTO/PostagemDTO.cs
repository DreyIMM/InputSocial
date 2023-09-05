using IPS.Feed.Domain.Models;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace IPS.Feed.API.DTO
{
    public record PostagensDTO
    {
        public Guid Id { get; set; }
        public Guid IdUsuario { get; set; }
        public DateTime DataPostagem { get; set; }
        public bool Modificado { get; set; }
        public string Mensagem { get; set; }
        public int TotalCurtidas { get; set; }
    }

    public record PostagemDTO
    {
        public Guid Id { get; set; }
        public Guid IdUsuario { get; set; }
        public DateTime DataPostagem { get; set; }
        public bool Modificado { get; set; }
        public string Mensagem { get; set; }
        public int TotalCurtidas { get; set; }
        public IEnumerable<ComentarioDTO> Comentarios { get; set; } = new List<ComentarioDTO>();
    }

    public record PostagemAddDTO
    {
        [JsonIgnore]
        public Guid IdUsuario { get; set; } 

        [JsonIgnore]
        public bool Modificado { get; set; } = false;

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [StringLength(290, ErrorMessage = "Seu input precisa está entre {2} e {1} caracteres", MinimumLength = 5)]
        public string Mensagem { get; set; }
    }
}