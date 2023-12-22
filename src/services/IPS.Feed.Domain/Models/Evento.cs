using IPS.Core.DomainObjects;
using IPS.Feed.Domain.Models.Enums;
using IPS.Feed.Domain.Models.Validations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IPS.Feed.Domain.Models
{
    public class Evento : Entity
    {
        public Guid IdUsuario { get; set; } = Guid.Empty;
        public string TituloEvento { get;set; } = string.Empty;
        public string DescricaoEvento { get; set; } = string.Empty;
        public bool Limite { get;set; }
        public int? QuantidadePessoas { get; set; }
        public StatusEnum StatusEvento { get; set; }
        public Endereco? Endereco { get; set; }

        public Evento() { }

        public Evento(string tituloEvento, string descricaoEvento, bool limite, int? quantidadePessoas, int statusEvento, Endereco? endereco)
        {
            TituloEvento = tituloEvento;
            DescricaoEvento = descricaoEvento;
            Limite = limite;
            QuantidadePessoas = quantidadePessoas;
            StatusEvento = (StatusEnum)statusEvento;
            Endereco = endereco;
        }

        internal bool EhValido()
        {
            ValidationResult = new EventoValidation().Validate(this);
            return ValidationResult.IsValid;
        }

    }
}
