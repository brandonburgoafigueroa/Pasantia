using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ResourceManagerSystem.Models
{
    public class Injury
    {
        public int ID { set; get; }
        public Injury RootInjury { set; get; }
        public ICollection<Injury> SubSectors { set; get; }
        public string Code { set; get; }
    }
}
