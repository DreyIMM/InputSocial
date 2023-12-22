using IPS.Feed.API.DTO;
using IPS.Feed.Domain.Models;

namespace IPS.Feed.API.Extensions
{
    public static class EventoExtensions
    {
        public static Evento ToUniqueEvento(this EventoAddDTO dto)
        {
            return new Evento(dto.TituloEvento, dto.DescricaoEvento, dto.Limite, dto.QuantidadePessoas, dto.StatusEvento, dto.Endereco?.ToUniqueEndereco());   
        }


        public static Endereco ToUniqueEndereco(this EnderecoAddDTO dto)
        {
            return new Endereco(dto.Bairro, dto.Regiao, dto.Numero, dto.Cep, dto.Latitude, dto.Longitude);
        }


    }
}
