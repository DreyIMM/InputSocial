using IPS.Feed.Infra.Data;
using IPS.Feed.Domain.Interfaces;
using IPS.Feed.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace IPS.Feed.Infra.Repository
{
    public class PostagemRepository : Repository<Postagem>, IPostagemRepository
    {
        public PostagemRepository(FeedContext context) : base(context) { }

        public async Task<List<Postagem>> ObterTodasPostagem()
        {
            return await Db.Postagem.AsNoTracking().Include(p => p.Curtidas).ToListAsync();
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
