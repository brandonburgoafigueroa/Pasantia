using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ResourceManagerSystem.Models
{
    public class AccidentEffect
    {
        public int ID { set; get; }
        public int InhabilityDays { set; get; }
        public ICollection<BodyPart> BodyPartsAffected { set; get; }
        public string Observation { set; get; }
    }
}
