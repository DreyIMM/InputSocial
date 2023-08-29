using IPS.Feed.API.DTO;
using IPS.Feed.API.Extensions;
using IPS.Feed.API.Interfaces;
using IPS.Feed.API.Services;
using IPS.WebApi.Core.Controllers;
using Microsoft.AspNetCore.Mvc;

namespace IPS.Feed.API.Controllers
{

    [Route("api/feed")]
    public class FeedController : MainController
    {
        private readonly IPostagemRepository _postagemRepository;
        private readonly IPostagemService _postagemService;
        public FeedController(IPostagemRepository postagemRepository, IPostagemService postagemService)
        {
            _postagemRepository = postagemRepository;
            _postagemService = postagemService;
        }

        [HttpGet]
        [ProducesResponseType(typeof(PostagensDTO), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IEnumerable<PostagensDTO>> ObterPostagens()
        {
            var result = await _postagemRepository.ObterTodasPostagem();

            return result.ToPostListDTO();            
                
        }

        [HttpGet("postagem/{id}")]
        [ProducesResponseType(typeof(PostagemDTO), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<PostagemDTO> PostagemDetalhe(Guid id)
        {   
            var result = await _postagemRepository.ObterDetalhePostagem(id);

            return result.ToUniquePostDTO();

        }

        [HttpPost("postagem")]
        [ProducesResponseType(typeof(PostagemAddDTO), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<PostagemAddDTO>> PostagemAdd([FromBody] PostagemAddDTO post)
        {
            if (!ModelState.IsValid) return CustomResponse(ModelState);


            await _postagemService.Adicionar(post);

            return Ok();
        }
    }    
}
