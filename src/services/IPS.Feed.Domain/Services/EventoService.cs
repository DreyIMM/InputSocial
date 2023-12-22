using FluentValidation.Results;
using IPS.Core.Messages;
using IPS.Feed.Domain.Interfaces;
using IPS.Feed.Domain.Models;
using IPS.WebApi.Core.Service;
using IPS.WebApi.Core.Usuario;

namespace IPS.Feed.Domain.Services
{
    public class EventoService : BaseService, IEventoService
    {
        private readonly IEventoRepository _eventoRepository;
        private readonly IAspNetUser _user;
        public EventoService(IEventoRepository eventoRepository, IAspNetUser user)
        {
            _eventoRepository = eventoRepository;
            _user = user;
        }

        public async Task<ValidationResult> Adicionar(Evento evento)
        {
            //
            evento.IdUsuario = _user.ObterUserId();
            //validar estrutura
            if (!evento.EhValido()) return evento.ValidationResult;

            //Salvar evento
            await _eventoRepository.Adicionar(evento);

            return new ValidationResult();
        }

    }
}
