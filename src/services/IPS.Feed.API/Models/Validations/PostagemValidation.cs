using FluentValidation;

namespace IPS.Feed.API.Models.Validations
{
    public class PostagemValidation : AbstractValidator<Postagem>
    {
        public PostagemValidation()
        {
            RuleFor(p => p.Id)
                .NotEqual(Guid.Empty)
                .WithMessage("ID da postagem não pode ser vázio");

            RuleFor(p => p.Mensagem)
                .NotEmpty()
                .MaximumLength(290)
                .WithMessage("Nome de usuário precisa ser inferior a 300");

        }
    }
}
