using FluentValidation.Results;
namespace IPS.WebApi.Core.Service
{
    public abstract class BaseService
    {
        protected ValidationResult ValidationResult;

        protected BaseService()
        {
            ValidationResult = new ValidationResult();
        }

        protected void AdicionarErro(string mensagem)
        {
            ValidationResult.Errors.Add(new ValidationFailure(string.Empty, mensagem));
        }

    }
}
