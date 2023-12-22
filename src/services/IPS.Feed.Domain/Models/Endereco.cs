using IPS.Core.DomainObjects;
using IPS.Feed.Domain.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IPS.Feed.Domain.Models
{
    public class Endereco : Entity
    {

        public string Bairro { get; set; } = string.Empty;
        public string Regiao { get; set; } = string.Empty;
        public string Numero { get; set; } = string.Empty;
        public string cep { get; set; } = string.Empty;
        public double Latitude { get; set; } 
        public double Longitude { get; set; }
        public Guid? EventoGuid { get; set; }
        public Evento Evento { get; set; }

        public Endereco(string bairro, string regiao, string numero, string cep, double latitude, double longitude)
        {
            Bairro = bairro;
            Regiao = regiao;
            Numero = numero;
            this.cep = cep;
            Latitude = latitude;
            Longitude = longitude;
        }
    }
}
