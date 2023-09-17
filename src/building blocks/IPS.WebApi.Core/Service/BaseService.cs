using FluentValidation.Results;
namespace IPS.WebApi.Core.Service
{
    public abstract class BaseService
    {
        protected ValidationResult validationResult;

        protected BaseService()
        {
            validationResult = new ValidationResult();
        }

        protected void AdicionarErro(string mensagem)
        {
            validationResult.Errors.Add(new ValidationFailure(string.Empty, mensagem));
        }

    }
}
