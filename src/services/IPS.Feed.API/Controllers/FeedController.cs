﻿using IPS.Feed.API.DTO;
using IPS.Feed.API.Extensions;
using IPS.Feed.Domain.Interfaces;
using IPS.Feed.Domain.Models;
using IPS.Feed.Domain.Services;
using IPS.WebApi.Core.Controllers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace IPS.Feed.API.Controllers
{

    [Route("api/feed")]
    [Authorize]
    public class FeedController : MainController
    {
        private readonly IPostagemRepository _postagemRepository;
        private readonly IPostagemService _postagemService;
        private readonly IComentarioService _comentarioService;
        private readonly IComentarioRepository _comentarioRepository;
        public FeedController(IPostagemRepository postagemRepository, IPostagemService postagemService, IComentarioService comentarioService, IComentarioRepository comentarioRepository)
        {
            _postagemRepository = postagemRepository;
            _postagemService = postagemService;
            _comentarioService = comentarioService;
            _comentarioRepository = comentarioRepository;
        }

        [HttpPost("postagem")]
        [ProducesResponseType(typeof(PostagemAddDTO), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<PostagemAddDTO>> PostagemAdd([FromBody] PostagemAddDTO postDTO)
        {
            if (!ModelState.IsValid) return CustomResponse(ModelState);
            Postagem post = new Postagem(postDTO.Modificado, postDTO.Mensagem);
            await _postagemService.Adicionar(post);

            return Ok(postDTO);
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
        public async Task<ActionResult<PostagemDTO>> PostagemDetalhe(Guid id)
        {   
            var result = await _postagemRepository.ObterDetalhePostagem(id);
            if (result is null)
            {
                AdicionarErroProcessamento("Postagem não encontrada");
                return CustomResponse();
            }
            return Ok(result.ToUniquePostDTO());
        }

        [HttpGet("postagens/perfil")]
        [ProducesResponseType(typeof(PostagensDTO), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<List<PostagensDTO>> PostagemDetalhe()
        {
            var result = await _postagemService.PostagensUsuario();
            
            return result.ToPostListDTO().ToList();
        }
        

        [HttpDelete("postagem/apagar/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult> PostagemRemove(Guid id)
        {
            var result = await _postagemService.Remover(id);

            if (!result)
            {
                AdicionarErroProcessamento("Publicação não pode ser excluída");
                return CustomResponse();
            }

            return Ok("Publicação excluída");
        }


        [HttpPost("postagem/{idComentario}/comentario")]
        [ProducesResponseType(typeof(ComentarioAddDTO), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<PostagemAddDTO>> PostagemAdd(Guid idComentario, [FromBody] ComentarioAddDTO dto)
        {
            if (!ModelState.IsValid) return CustomResponse(ModelState);

            Comentario comentario = new Comentario(idComentario, dto.Mensagem);
            await _comentarioService.Adicionar(comentario);

            return Ok(comentario);
        }



    }    
}
