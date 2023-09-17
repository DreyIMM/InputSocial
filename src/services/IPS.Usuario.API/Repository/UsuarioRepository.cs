using FluentValidation.Results;
using IPS.Usuario.API.Data;
using IPS.Usuario.API.Models;
using IPS.WebApi.Core.Service;
using Microsoft.EntityFrameworkCore;

namespace IPS.Usuario.API.Repository
{
    public class UsuarioRepository : BaseService,IUsuarioRepository
    {
        private readonly UsuarioContext _context;

        public UsuarioRepository(UsuarioContext context)
        {
            _context = context;
        }

        

        //Formato para o grupo entender (não é a implementação ideal)
        public async Task<ValidationResult> Adicionar(UsuarioLogado usuario)
        {

            var existeCelular = await ExisteCelular(usuario.Celular);
            var existeUser = await ExisteUser(usuario.UserName);



            if (existeUser)   {
                AdicionarErro("Username já cadastrado!");
            }

            if (existeCelular) {                  
                AdicionarErro("Celular já cadastrado!");
            }


            if (existeUser || existeCelular)
            {
                return validationResult;
            }

            _context.AddAsync(usuario);
            await SaveChanges();

            return validationResult;
        }

        public async Task<int> SaveChanges()
        {
            return  _context.SaveChanges();
        }

        public void Dispose()
        {
            _context?.Dispose();
        }

        public async Task<bool> ExisteCelular(string celular)
        {
           return await _context.Usuarios.AsNoTracking().Where(u => u.Celular.Equals(celular)).AnyAsync();
        }

        public async Task<bool> ExisteUser(string username)
        {
            return await _context.Usuarios.AsNoTracking().Where(u => u.UserName.ToLower() == username.ToLower()).AnyAsync();
        }
    }
}
