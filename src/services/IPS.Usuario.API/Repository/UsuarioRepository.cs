using IPS.Core.DomainObjects;
using IPS.Usuario.API.Data;
using IPS.Usuario.API.Models;
using Microsoft.EntityFrameworkCore;

namespace IPS.Usuario.API.Repository
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private readonly UsuarioContext _context;
        protected readonly DbSet<UsuarioLogado> DbSet;

        public UsuarioRepository(UsuarioContext context)
        {
            _context = context;
            DbSet = context.Set<UsuarioLogado>();
        }

        public async Task Adicionar(UsuarioLogado usuario)
        {
            DbSet.Add(usuario);
            await SaveChanges();
        }

        public async Task<int> SaveChanges()
        {
            return await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            _context?.Dispose();
        }
    }
}
