using IPS.Feed.Domain.Interfaces;
using IPS.Feed.Domain.Models;
using IPS.WebApi.Core.Usuario;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IPS.Feed.Domain.Services
{
    public class CurtidaService : ICurtidaService
    {
        private readonly ICurtidaRepository _curtidaRepository;
        private readonly IAspNetUser _user;

        public CurtidaService(ICurtidaRepository curtidaRepository, IAspNetUser user)
        {
            _curtidaRepository = curtidaRepository;
            _user = user;
        }

        public async Task<string> Adicionar(Guid idPostagem)
        {
            Guid userId = _user.ObterUserId();
            Curtida curtida = new Curtida(userId, idPostagem);

            var result = await _curtidaRepository.ExisteCurtida(userId, idPostagem);

            if (result is not null)
            {
                try
                {
                    await _curtidaRepository.Remover(result.Id);
                }
                catch 
                {
                    return "Erro ao processar curtida no banco de dados";
                }
                return "Curtida removida";
            }
            else
            {
                try
                {
                    await _curtidaRepository.Adicionar(curtida);
                }
                catch
                {
                    return "Erro ao processar curtida no banco de dados";
                }
                return "Curtida adicionada";
            }
        }
    }
}
