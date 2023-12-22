using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IPS.Feed.Domain.Models.Validations
{
    public class EventoValidation : AbstractValidator<Evento>
    {
        public EventoValidation()
        {
            RuleFor(p => p.Id)
                .NotEqual(Guid.Empty)
                .WithMessage("ID da postagem não pode ser vázio");

            RuleFor(p => p.IdUsuario)
                .NotEqual(Guid.Empty)
                .WithMessage("ID do usuario é necessário");

            RuleFor(p => p.TituloEvento)
                .NotEmpty()
                .MaximumLength(150)
                .WithMessage("Titulo com até 150 caracteres");

            RuleFor(p => p.DescricaoEvento)
                .NotEmpty()
                .MaximumLength(300)
                .WithMessage("Descrição com até 300 caracteres");

        }
    }
}
