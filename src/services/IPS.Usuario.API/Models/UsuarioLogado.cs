using FluentValidation;
using IPS.Core.DomainObjects;
using System.ComponentModel.DataAnnotations.Schema;

namespace IPS.Usuario.API.Models
{
    public class UsuarioLogado : Entity
    {
        public string UserName { get; set; }
        public string Celular { get; set; }
        public DateTime DataAniversario { get; set; }

        [NotMapped]
        public Stream FotoPerfil { get; set; }

        [NotMapped]
        public string ExtFile { get; set; }

        public UsuarioLogado(Guid id, string userName, string celular, DateTime dtAniversario, Stream fotoPerfil, string extFile = ".jpg")
        {
            Id = id;
            UserName = userName;
            Celular = celular;
            DataAniversario = dtAniversario;
            FotoPerfil = fotoPerfil;
            ExtFile = extFile;
        }

        public bool AtualizarCelular(string celular)
        {
            Celular = celular;
            //Validar (estrutura e em seguida envia codigo para celular)
            return true;
        }

        internal bool EhValido()
        {
            return new UsuarioLogadoValidation().Validate(this).IsValid;
        }

        //EF 
        public UsuarioLogado() { }
    
    
    }

    public class UsuarioLogadoValidation : AbstractValidator<UsuarioLogado>
    { 
        public UsuarioLogadoValidation()
        {
            RuleFor(u => u.Id)
                .NotEqual(Guid.Empty)
                .WithMessage("ID do usuário invalido");

            RuleFor(u => u.UserName)
                .NotEmpty()
                .MaximumLength(300)
                .WithMessage("Nome de usuário precisa ser inferior a 300");

            RuleFor(c => c.Celular)
                .NotEmpty()
                .WithMessage("Numero do celular precisa ser informado");

            RuleFor(c => c.DataAniversario)
                .NotEmpty()
                .WithMessage("Data de aniversario precisa ser informada");

        }
    }


}
