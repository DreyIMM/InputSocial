using FluentValidation.Results;
using System.Text.Json;
using System.Text;

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

        protected StringContent ObterConteudo(object dado)
        {
            return new StringContent(
                JsonSerializer.Serialize(dado),
                Encoding.UTF8,
                "application/json");
        }

        protected async Task<T> DeserializarObjetoResponse<T>(HttpResponseMessage responseMessage)
        {
            var options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            };

            return JsonSerializer.Deserialize<T>(await responseMessage.Content.ReadAsStringAsync(), options);
        }

        protected async Task<T> DeserializarObjetoResponse<T>(String responseMessage)
        {
            var options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            };

            return JsonSerializer.Deserialize<T>(responseMessage.ToString(), options);
        }

    }
}
