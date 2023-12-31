﻿using IPS.Feed.Infra;
using IPS.Feed.Domain.Interfaces;
using IPS.Feed.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace IPS.Feed.Infra.Repository
{
    public class PostagemRepository : Repository<Postagem>, IPostagemRepository
    {

        private readonly IUsuarioService _usuarioService;

        public PostagemRepository(FeedContext context, IUsuarioService usuarioserivce ) : base(context)
        {
            _usuarioService = usuarioserivce;
        }

        public async Task<List<Postagem>> ObterTodasPostagem()
        {
            List<Postagem> result = await Db.Postagem.AsNoTracking().Include(p => p.Curtidas).ToListAsync();

            
            foreach(var postagem in result)
            {
                Guid idUsuario = Guid.Parse(postagem.IdUsuario.ToString());
                postagem.NomeUsuario = await _usuarioService.ObterNomeUsuario(idUsuario);
            }

            return result;
        }

        public async Task<Postagem> ObterDetalhePostagem(Guid Idpostagem)
        {

            var result = await Db.Postagem.AsNoTracking().Include(p => p.Curtidas).Include(p => p.Comentarios).FirstOrDefaultAsync(p => p.Id == Idpostagem);
            
            Guid idUsuario = Guid.Parse(result.IdUsuario.ToString());
            result.NomeUsuario = await _usuarioService.ObterNomeUsuario(idUsuario);

            if (result.Comentarios.Any()) 
            {                
                foreach (var item in result.Comentarios)
                 {
                   var nome = await _usuarioService.ObterNomeUsuario(item.IdUsuario);
                   item.NomeUsuario = nome;
                 }
            }

            return result;
        }

        public async Task<bool> PostagemUsuario(Guid IdUser, Guid Idpostagem)
        {
            return Db.Postagem.AsNoTracking().Where(p => p.Id.Equals(Idpostagem) && p.IdUsuario.Equals(IdUser)).Any();
        }

        public async Task<List<Postagem>> PostagensUsuario(Guid IdUser)
        {
            return await Db.Postagem.AsNoTracking().Include(p => p.Curtidas).Include(p => p.Comentarios).Where(p => p.IdUsuario.Equals(IdUser)).ToListAsync();
        }

        public async Task<List<string>> ObterPostagensMoments()
        {
            DateTime dtInicio = DateTime.Now;
            DateTime dtFim = dtInicio.AddMinutes(-15);

            return await Db.Postagem
                    .AsNoTracking()
                    .Where(p => p.DataPostagems <= dtInicio && p.DataPostagems >= dtFim)
                    .Select(p => p.EntidadesNlp)
                    .Take(5)
                    .ToListAsync();
        }

    }
}
