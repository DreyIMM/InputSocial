using IPS.Usuario.API.Models;
using Microsoft.EntityFrameworkCore;

namespace IPS.Usuario.API.Data
{
    public class UsuarioContext : DbContext
    {
        public UsuarioContext(DbContextOptions<UsuarioContext> options) : base(options) { }

        public DbSet<UsuarioLogado> Usuarios { get; set; }

    }
}
