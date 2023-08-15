using IPS.Usuario.API.Models;
using IPS.Usuario.API.Services;
using IPS.WebApi.Core.Controllers;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace IPS.Usuario.API.Controllers
{
    public class UsuarioController : MainController
    {
        private readonly IUsuarioService _userService;
        public UsuarioController(IUsuarioService userService)
        {
            _userService = userService;
        }
        
        [HttpPost("novo-usuario")]
        public ActionResult Create([FromBody] UsuarioLogado user)
        {   
           _userService.Adicionar(new UsuarioLogado("drey", 2222222, DateTime.Now));
            return Ok();
        }
    }
}
