using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ResourceManagerSystem.Models
{
    public abstract class Sinister
    {
        public int SinisterID { set; get; }
        public string Description { set; get; }
        public DateTime Date { set; get; }

    }
}
