using IPS.Feed.Domain.Interfaces;
using IPS.Feed.Domain.Models;
using IPS.Feed.Infra;
using IPS.Feed.Infra.Repository;
using Microsoft.EntityFrameworkCore;

namespace IPS.Feed.Infa.Repository
{
    public class CurtidaRepository : Repository<Curtida>, ICurtidaRepository
    {
        public CurtidaRepository(FeedContext context) : base(context) { }

        public Task<Curtida> ExisteCurtida(Guid idUser, Guid idPostagem)
        {
            return Db.Curtidas.AsNoTracking().Where(c => c.IdPostagem.Equals(idPostagem) && c.IdUsuario.Equals(idUser)).FirstOrDefaultAsync();
        }
    }
}
