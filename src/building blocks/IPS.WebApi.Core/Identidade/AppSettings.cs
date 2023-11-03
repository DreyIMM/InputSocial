using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IPS.WebApi.Core.Identidade
{
    public class AppSettings
    {
        public string Secret { get; set; }
        public int ExpiracaoHoras { get; set; }
        public string Emissor { get; set; }
        public string ValidoEm { get; set; }
        public string ConnectionString { get; set; }
        public string ApiUrlUsuario { get; set; }

    }
}
