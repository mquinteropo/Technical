using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TECHNICAL.APP.Model
{
    public class PersonModel
    {
        public int id { get; set; }
        public string name { get; set; }
        public int age { get; set; }
        public TypeModel type { get; set; }
    }
    public class TypeModel
    {
        public int type { get; set; }
        public string description { get; set; }
    }
}