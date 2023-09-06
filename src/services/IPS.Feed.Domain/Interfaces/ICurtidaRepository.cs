using IPS.Feed.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IPS.Feed.Domain.Interfaces
{
    public interface ICurtidaRepository : IRepository<Curtida>
    {
        Task<Curtida> ExisteCurtida(Guid idUser, Guid idCurtida);
    }
}
