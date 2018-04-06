using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ResourceManagerSystem.Models
{
    public class BodyPart
    {
        public int BodyPartID { set; get; }
        public string Name { set; get; }

        public ICollection<BodyPartsAffected> BodyPartsAffected { set; get; }
    }
}
