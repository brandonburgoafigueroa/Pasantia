using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ResourceManagerSystem.Models
{
    
    public class CollectionREPP
    {
        public int CollectionREPPID { set; get; }
        [Display(Name ="REPP")]
        [Required(ErrorMessage ="El REPP no puede estar vacio")]
        public int ReppID { set; get; }
        [Display(Name = "Cargo operativo")]
        [Required(ErrorMessage = "El cargo operativo no puede estar vacio")]
        public int OperativeID { set; get; }


        public REPP REEP { set; get; }
        public Operative Operative { set; get; }
    }
}
