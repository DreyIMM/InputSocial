using IPS.Core.DomainObjects;
using IPS.Feed.Domain.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IPS.Feed.Domain.Models
{
    public class Endereco
    {

        public string Bairro { get; set; } = string.Empty;
        public string Cidade { get; set; } = string.Empty;
        public string Numero { get; set; } = string.Empty;
        public string Cep { get; set; } = string.Empty;
        public double Latitude { get; set; } 
        public double Longitude { get; set; }

        public Endereco(string bairro, string cidade, string numero, string cep, double latitude, double longitude)
        {
            Bairro = bairro;
            Cidade = cidade;
            Numero = numero;
            Cep = cep;
            Latitude = latitude;
            Longitude = longitude;
        }
    }
}
