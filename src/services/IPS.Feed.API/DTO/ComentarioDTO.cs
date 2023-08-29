namespace IPS.Feed.API.DTO
{
        public record ComentarioDTO
        {
            public Guid Id { get; set; }
            public Guid IdUsuario { get; set; }
            public Guid IdPostagem { get; set; }
            public DateTime DataComentario { get; set; }
            public string Mensagem { get; set; }
        }       
    
}