using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ResourceManagerSystem.Models
{
    [DisplayName("Coleccion De Repp")]
    public class CollectionREPP
    {
        [Key]
        [Display(Name = "REPP")]
        public int ReppID { set; get; }

        [Key]
        [DisplayName("Cargo Operativo")]
        public int OperativeID { set; get; }

        [NotMapped]
        public ICollection<int> SelectedRepp { set; get; }
        public REPP REEP { set; get; }
        public Operative Operative { set; get; }
    }
}
