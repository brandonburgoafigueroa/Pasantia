using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ResourceManagerSystem.Models
{
    public class AccidentEffect
    {
        public int AccidentEffectID { set; get; }
        public int InhabilityDays { set; get; }
        public string Observation { set; get; }

        public ICollection<BodyPartsAffected> BodyPartsAffected { set; get; }
    }
}
