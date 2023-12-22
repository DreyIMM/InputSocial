using IPS.Feed.Domain.Models.Enums;
using IPS.Feed.Domain.Models;
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace IPS.Feed.API.DTO
{
    public record EventoAddDTO
    {
        [JsonIgnore]
        public Guid IdUsuario { get; init; }
        public string TituloEvento { get; init; }
        public string DescricaoEvento { get; init; } 
        public bool Limite { get; init; }
        public int? QuantidadePessoas { get; init; }
        public int StatusEvento { get; init; }
        public EnderecoAddDTO? Endereco { get; init; }
    }

}