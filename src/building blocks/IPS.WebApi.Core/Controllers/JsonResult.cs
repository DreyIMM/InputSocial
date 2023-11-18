using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IPS.WebApi.Core.Controllers
{
    public class ResponseModel
    {
        public string Content { get; set; }
        public string ContentType { get; set; }
        public int? StatusCode { get; set; }
    }
    public class ResponseModelNLP
    {
        public List<string> loc { get; set; }
        public List<string> verb { get; set; }    
    }


}
