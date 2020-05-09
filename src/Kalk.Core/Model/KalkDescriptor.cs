using System.Collections.Generic;

namespace Kalk.Core
{
    public class KalkDescriptor
    {
        public KalkDescriptor()
        {
            Names = new List<string>();
            Params = new List<KalkParamDescriptor>();
        }

        public List<string> Names { get;}

        public bool IsCommand { get; set; }

        public string Category { get; set; }
        
        public string Description { get; set; }

        public List<KalkParamDescriptor> Params { get; }

        public string Syntax { get; set; }

        public string Returns { get; set; }

        public string Remarks { get; set; }

        public string Example { get; set; }
    }
    
    public class KalkParamDescriptor
    {
        public KalkParamDescriptor()
        {
        }

        public KalkParamDescriptor(string name, string description)
        {
            Name = name;
            Description = description;
        }

        public string Name { get; set; }

        public string Description { get; set; }

        public bool IsOptional { get; set; }
    }
}