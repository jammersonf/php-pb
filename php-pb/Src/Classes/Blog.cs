using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace php_pb.Src.Classes
{
    public class Blog : Model
    {
        public String Title { get; set; }
        public String Description { get; set; }
        public String Date { get; set; }
        public String Link { get; set; }
    }
}
