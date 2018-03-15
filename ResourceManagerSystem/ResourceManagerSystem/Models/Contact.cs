using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ResourceManagerSystem.Models
{
    public class Contact : Person
    {
        public Provider Provider { set; get; }
    }
}
