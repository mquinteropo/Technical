using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TECHNICAL.MODELS
{
    public class ResponseTypesModel
    {
        public bool success { get; set; } = false;
        public string message { get; set; }
        public List<TypeModel> data { get; set; }
    }
}
