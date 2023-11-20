using IPS.Feed.Domain.Interfaces;

namespace IPS.Feed.API.Services
{
       
    public class BairrosService : IScopedBairrosService
    {
        private readonly IPostagemRepository _postagemRepository;

        public BairrosService(IPostagemRepository postagemRepository) 
        {
            _postagemRepository = postagemRepository;
        }
      


        public async Task DoWork()
        {
            _postagemRepository.ObterTodasPostagem();
           
        }
    }

}
