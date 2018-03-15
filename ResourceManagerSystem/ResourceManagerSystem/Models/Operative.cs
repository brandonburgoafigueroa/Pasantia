using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ResourceManagerSystem.Models
{
    public abstract class Operative
    {
        [Key]
        public int Id { set; get; }
        public string Code { set; get; }
        public string Name { set; get; }
        public Region Region { set; get; }
        public virtual ICollection<REPP> REPS { set; get; }

    }
}
