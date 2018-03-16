using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ResourceManagerSystem.Models
{
    public class CollectionREPP
    {
        public int ID { set; get; }
        public int ReppID { set; get; }
        public int OperativeID { set; get; }

        public REPP REEP { set; get; }
        public Operative Operative { set; get; }
    }
}
