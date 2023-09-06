using IPS.Feed.Domain.Interfaces;
using IPS.Feed.Domain.Models;
using IPS.Feed.Infra.Data;
using IPS.Feed.Infra.Repository;


namespace IPS.Feed.Infa.Repository
{
    public class ComentarioRepository : Repository<Comentario>, IComentarioRepository
    {
        public ComentarioRepository(FeedContext context) : base(context) { }   

    }
}
