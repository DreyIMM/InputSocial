using IPS.Feed.Domain.Interfaces;
using IPS.Feed.Domain.Services;
using IPS.WebApi.Core.Controllers;
using IPS.WebApi.Core.Identidade;
using IPS.WebApi.Core.Service;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Options;
using System;
using System.Dynamic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;

namespace IPS.Feed.API.Services
{

    public class UsuarioService : BaseService, IUsuarioService
    {
        private readonly HttpClient _httpClient;
        private readonly IServiceProvider _serviceProvider;


        public UsuarioService(HttpClient httpClient, IOptions<AppSettings> settings, IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
            _httpClient = httpClient;
            _httpClient.BaseAddress = new Uri(settings.Value.ApiUrlUsuario);    
        }

        public async Task<string> ObterNomeUsuario(Guid idUsuario)
        {

            var response = await _httpClient.GetStringAsync($"usuario/nomeusuario?idUsuario={idUsuario}");

            var responseModel = DeserializarObjetoResponse<ResponseModel>(response);

            return responseModel.Result.Content;
        }

        public async Task ProcessarMensagemNLP(Guid id, string mensagem)
        {
            //Gambiarra
            _httpClient.BaseAddress = new Uri("http://127.0.0.1:5000");

            var reqbody = new { mensagem };

            var json = ObterConteudo(reqbody);

            var postReponse = await _httpClient.PostAsync("/processar_mensagem", json);

            var result = await DeserializarObjetoResponse<ResponseModelNLP>(postReponse);

            string textps = "";

            result.loc.ForEach(c =>
            {
                textps += $" {c}; ";
            });

            using (var scoped = _serviceProvider.CreateScope())
            {
                var service = scoped.ServiceProvider.GetRequiredService<IPostagemService>();

                await service.AtualizarPost(id, textps.ToString());
            }

        }
    }
}
