using IPS.Feed.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace IPS.Feed.Infra
{
    public class FeedContext : DbContext
    {
        public FeedContext() : base() { } 
        public FeedContext(DbContextOptions<FeedContext> options) : base(options) { }

        public DbSet<Postagem> Postagem { get; set; }
        public DbSet<Curtida> Curtidas { get; set; }
        public DbSet<Comentario> Comentarios { get; set; }
        public DbSet<RelacaoSeguindo> Seguidores { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                IConfigurationRoot configuration = new ConfigurationBuilder()
                    .SetBasePath("D:\\Desenvolvimento\\InputSocial\\src\\services\\IPS.Feed.API")
                    .AddJsonFile("appsettings.json")
                    .Build();

                var connectionString = configuration.GetConnectionString("DefaultConnection");
                optionsBuilder.UseNpgsql(connectionString);
            }
        }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(
                 typeof(FeedContext).Assembly);
        }
    }
}
