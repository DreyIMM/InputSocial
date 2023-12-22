using IPS.Feed.Domain.Interfaces;
using IPS.Feed.Domain.Models;
using IPS.Feed.Infra;
using IPS.Feed.Infra.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IPS.Feed.Infa.Repository
{
    public class EventoRepository : Repository<Evento>, IEventoRepository
    {
        private readonly IUsuarioService _usuarioService;

        public EventoRepository(FeedContext context, IUsuarioService usuarioService): base(context) 
        {
            _usuarioService = usuarioService;
        }
    }
}
