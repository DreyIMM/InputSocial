using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IPS.Core.Messages
{
    public class UsuarioRegistradoIntegrationEvent : IntegrationEvent
    {
        public Guid Id { get; private set; }
        public string UserName { get; set; }
        public string Celular { get; set; }
        public DateTime DataAniversario { get; set; }
        public byte[] FotoPerfil { get; set; }
        public string ExtensionFile { get; set; }

        public UsuarioRegistradoIntegrationEvent(Guid id, string userName, string celular, DateTime dtAniversario, byte[] foto, string exFile)
        {
            Id = id;
            UserName = userName; 
            Celular = celular;
            DataAniversario = dtAniversario;
            FotoPerfil = foto;
            ExtensionFile = exFile;
        }
    }
}