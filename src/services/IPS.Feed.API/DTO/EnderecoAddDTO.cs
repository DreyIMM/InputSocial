namespace IPS.Feed.API.DTO
{
    public record EnderecoAddDTO
    {
        public string Bairro { get; init; }
        public string Regiao { get; init; } 
        public string Numero { get; init; } 
        public string Cep { get; init; }
        public double Latitude { get; init; }
        public double Longitude { get; init; }
    }
}
