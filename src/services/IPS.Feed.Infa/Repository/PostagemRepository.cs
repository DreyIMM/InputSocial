using IPS.Feed.Infra.Data;
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
            return await Db.Postagem.AsNoTracking().Include(p => p.Curtidas).Include(p => p.Comentarios).FirstOrDefaultAsync(p => p.Id == Idpostagem);
        }

        public async Task<bool> PostagemUsuario(Guid IdUser, Guid Idpostagem)
        {
            return Db.Postagem.AsNoTracking().Where(p => p.Id.Equals(Idpostagem) && p.IdUsuario.Equals(IdUser)).Any();
        }

        public async Task<List<Postagem>> PostagensUsuario(Guid IdUser)
        {
            return await Db.Postagem.AsNoTracking().Include(p => p.Curtidas).Include(p => p.Comentarios).Where(p => p.IdUsuario.Equals(IdUser)).ToListAsync();
        }
    }
}
