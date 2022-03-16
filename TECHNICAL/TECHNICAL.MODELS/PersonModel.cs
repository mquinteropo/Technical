using System;

namespace TECHNICAL.MODELS
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
