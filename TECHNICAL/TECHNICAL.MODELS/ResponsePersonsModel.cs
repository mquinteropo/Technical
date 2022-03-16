using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TECHNICAL.MODELS
{
    public class ResponsePersonsModel
    {
        public bool success { get; set; } = false;
        public string message { get; set; }
        public List<PersonModel> data { get; set; }
    }
}
