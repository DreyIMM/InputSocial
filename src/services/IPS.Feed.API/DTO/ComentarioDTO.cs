using System.Text.Json.Serialization;

namespace IPS.Feed.API.DTO
{
        public record ComentarioAddDTO
        {
            [JsonIgnore]
            public Guid IdUsuario { get; set; }
            public string Mensagem { get; set; }
        }

        public record ComentarioViewDTO
        {
            [JsonIgnore]
            public Guid IdUsuario { get; set; }
            public string Mensagem { get; set; } = string.Empty;
            public string NomeUsuarioComentario { get; set; } = string.Empty;
    }

}