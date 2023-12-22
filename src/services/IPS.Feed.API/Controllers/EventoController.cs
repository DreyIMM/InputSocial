using IPS.Feed.API.DTO;
using IPS.Feed.API.Extensions;
using IPS.Feed.Domain.Interfaces;
using IPS.Feed.Domain.Models;
using IPS.WebApi.Core.Controllers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;


namespace IPS.Feed.API.Controllers
{

    [Route("api/evento")]
    [Authorize]
    public class EventoController : MainController
    {
        private readonly IEventoService _eventoService;

        public EventoController(IEventoService eventoService)
        {
            _eventoService = eventoService;
        }

        [HttpPost("criar")]
        [ProducesResponseType(typeof(EventoAddDTO), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<EventoAddDTO>> EventoAdd([FromBody] EventoAddDTO eventoDTO)
        {
            if (!ModelState.IsValid) { return CustomResponse(ModelState); }

            Evento evento = eventoDTO.ToUniqueEvento();

            var result = await _eventoService.Adicionar(evento);

            if (!result.IsValid) { return CustomResponse(result); }

            return CustomResponse("Evento criado com sucesso");
        }




    }
}
