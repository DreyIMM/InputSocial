using IPS.Feed.Domain.Interfaces;
using IPS.WebApi.Core.Controllers;
using IPS.WebApi.Core.Identidade;
using IPS.WebApi.Core.Service;
using Microsoft.Extensions.Options;

namespace IPS.Feed.API.Services
{

    public class UsuarioService : BaseService, IUsuarioService
    {
        private readonly HttpClient _httpClient;
        

        public UsuarioService(HttpClient httpClient, IOptions<AppSettings> settings)
        {
            _httpClient = httpClient;
            _httpClient.BaseAddress = new Uri(settings.Value.ApiUrlUsuario);
        }

        public async Task<string> ObterNomeUsuario(Guid idUsuario)
        {

            var response = await _httpClient.GetStringAsync($"usuario/nomeusuario?idUsuario={idUsuario}");

            var responseModel = DeserializarObjetoResponse<ResponseModel>(response);

            return responseModel.Result.Content;
        }
    }
}
