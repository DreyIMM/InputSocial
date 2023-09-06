using System.Text.Json.Serialization;

namespace IPS.Feed.API.DTO
{
        public record ComentarioAddDTO
        {
            [JsonIgnore]
            public Guid IdUsuario { get; set; }
            public string Mensagem { get; set; }
        }       
    
}