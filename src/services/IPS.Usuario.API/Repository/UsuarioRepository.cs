using Firebase.Auth;
using Firebase.Storage;
using FluentValidation.Results;
using IPS.Usuario.API.Data;
using IPS.Usuario.API.Models;
using IPS.WebApi.Core.Service;
using Microsoft.EntityFrameworkCore;
using IHostingEnvironment = Microsoft.AspNetCore.Hosting.IHostingEnvironment;

namespace IPS.Usuario.API.Repository
{
    public class UsuarioRepository : BaseService,IUsuarioRepository
    {
        private readonly UsuarioContext _context;
        private IHostingEnvironment Environment;

        public string apikey = "AIzaSyA011CDQhyG_ARZ7ako1Bbp8h0bzvcSXI4";
        public string Bucket = "ips-tcc.appspot.com";
        public string AuthEmail = "ips@dev.com";
        public string AuthPassword = "P@ssword@2024.";
        public UsuarioRepository(UsuarioContext context, IHostingEnvironment env)
        {
            _context = context;
            Environment = env;
        }

        public async void UploadFirebase(Stream fotoPerfil, Guid idUsuario, string extensionFile)
        {
            if(fotoPerfil.Length ==0)
            {
                var pathFolder = Path.Combine(this.Environment.WebRootPath, "profile-account.jpg");
                extensionFile = ".jpg";
                fotoPerfil = File.Open(pathFolder, FileMode.Open);
            }

            using (Stream stream = fotoPerfil)
            {
                var auth = new FirebaseAuthProvider(new FirebaseConfig(apikey));
                var a = await auth.SignInWithEmailAndPasswordAsync(AuthEmail, AuthPassword);
                var cancellationToken = new CancellationToken();
                var task = new FirebaseStorage(
                Bucket,
                new FirebaseStorageOptions
                {
                    AuthTokenAsyncFactory = () => Task.FromResult(a.FirebaseToken),
                    ThrowOnCancel = true 
                })
                .Child("ipsfotos")
                .Child($"{idUsuario}{extensionFile}")
                .PutAsync(stream, cancellationToken);

                var downloadUrl = await task;

            };
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
            UploadFirebase(usuario.FotoPerfil, usuario.Id, usuario.ExtFile);
            await SaveChanges();

            return validationResult;
        }


        //Repository - buscar nome do usuario
        
        public string ObterUsuario(Guid idUsuario)
        {
            return _context.Usuarios.AsNoTracking().Where(p => p.Id == idUsuario).Select(p => p.UserName).FirstOrDefault().ToString();
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
