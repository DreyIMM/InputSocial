using IPS.Feed.API.Models;
using Microsoft.EntityFrameworkCore;

namespace IPS.Feed.API.Data
{
    public class FeedContext : DbContext
    {
        public FeedContext(DbContextOptions<FeedContext> options) : base(options) { }

        public DbSet<Postagem> Postagem { get; set; }
        public DbSet<Curtida> Curtidas { get; set; }
        public DbSet<Comentario> Comentarios { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(
                typeof(FeedContext).Assembly);
        }
    }
}
