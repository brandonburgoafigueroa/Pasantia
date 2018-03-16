using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ResourceManagerSystem.Models
{
    public class BodyPart
    {
        public int ID { set; get; }
        public BodyPart RootPart { set; get; }
        public ICollection<BodyPart> SubSectors { set; get; }
        public string Code { set; get; }
    }
}
