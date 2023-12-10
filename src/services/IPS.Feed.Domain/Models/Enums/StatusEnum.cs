using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace IPS.Feed.Domain.Models.Enums
{
    public enum StatusEnum
    {
        [Display(Name = "Em andamento")]
        EmAndamento = 1,
        [Display(Name = "Concluído")]
        Concluido,
        [Display(Name = "Finalizado")]
        Finalizado,
        [Display(Name = "Cancelado")]
        Cancelado
    }
}
