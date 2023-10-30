using IPS.Usuario.API.Models;
using IPS.Usuario.API.Repository;
using IPS.Usuario.API.Services;
using IPS.WebApi.Core.Controllers;
using Microsoft.AspNetCore.Mvc;

namespace IPS.Usuario.API.Controllers
{
    [Route("api/usuario")]
    public class UsuarioController : MainController
    {
        private readonly IUsuarioRepository _repository;
        public UsuarioController(IUsuarioRepository userService)
        {
            _repository = userService;
        }


        [HttpGet("nomeusuario")]
        public ActionResult<string> NomeUsuario([FromQuery] Guid idUsuario)
        {
            if (idUsuario.Equals("")) return CustomResponse("Id usuario vazio");

            var usuario = _repository.ObterUsuario(idUsuario);

            return Ok(new JsonStringResult(usuario));
        }

    }
}
