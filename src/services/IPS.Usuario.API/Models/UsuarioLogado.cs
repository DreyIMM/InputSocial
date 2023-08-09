using FluentValidation;
using IPS.Core.DomainObjects;

namespace IPS.Usuario.API.Models
{
    public class UsuarioLogado : Entity
    {
        public string UserName { get; set; }
        public int Celular { get; set; }
        public DateTime DataAniversario { get; set; }


        public UsuarioLogado(string userName, int celular, DateTime dtAniversario)
        {
            UserName = userName;
            Celular = celular;
            DataAniversario = dtAniversario;
        }

        public bool AtualizarCelular(int celular)
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
