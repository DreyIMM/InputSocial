using IPS.Core.DomainObjects;

namespace IPS.Feed.Domain.Models
{
    public class RelacaoSeguindo : Entity
    {
        public Guid IdUsuario { get; set; }
        public Guid IdSeguidores { get; set; }
    }
}
