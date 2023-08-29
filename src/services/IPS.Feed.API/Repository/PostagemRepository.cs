using IPS.Feed.API.Data;
using IPS.Feed.API.Interfaces;
using IPS.Feed.API.Models;
using Microsoft.EntityFrameworkCore;

namespace IPS.Feed.API.Repository
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
    }
}
