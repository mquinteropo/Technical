using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TECHNICAL.APP.Model
{
    public class ServiceTypesResponse
    {
        public bool success { get; set; } = false;
        public string message { get; set; }
        public List<TypeModel> data { get; set; }

    }
}