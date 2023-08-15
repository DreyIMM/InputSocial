using IPS.Usuario.API.Models;
using IPS.Usuario.API.Repository;

namespace IPS.Usuario.API.Services
{
    public class  UsuarioService: IUsuarioService
    {

        private readonly IUsuarioRepository _userRepository;

        public UsuarioService(IUsuarioRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task Adicionar(UsuarioLogado usuario)
        {
             if (!usuario.EhValido()) return;
             await _userRepository.Adicionar(usuario);
        }
    }

}
