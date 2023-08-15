using IPS.Core.DomainObjects;
using IPS.Usuario.API.Data;
using IPS.Usuario.API.Models;
using Microsoft.EntityFrameworkCore;

namespace IPS.Usuario.API.Repository
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private readonly UsuarioContext _context;

        public UsuarioRepository(UsuarioContext context)
        {
            _context = context;
        }

        public async Task Adicionar(UsuarioLogado usuario)
        {
            _context.AddAsync(usuario);
            await SaveChanges();
        }

        public async Task<int> SaveChanges()
        {
            return  _context.SaveChanges();
        }

        public void Dispose()
        {
            _context?.Dispose();
        }
    }
}
