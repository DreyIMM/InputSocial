using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IPS.Core.Messages
{
    public class UsuarioRegistradoIntegrationEvent : IntegrationEvent
    {
        public Guid Id { get; private set; }
        public string UserName { get; set; }
        public int Celular { get; set; }
        public DateTime DataAniversario { get; set; }

        public UsuarioRegistradoIntegrationEvent(Guid id, string userName, int celular, DateTime dtAniversario)
        {
            Id = id;
            UserName = userName; 
            Celular = celular;
            DataAniversario = dtAniversario;
        }
    }
}