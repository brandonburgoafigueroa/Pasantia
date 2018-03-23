using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ResourceManagerSystem.Models
{
    [DisplayName("REPP")]
    public class REPP
    {
        [Display(Name = "REPP")]
        public int ReppID { set; get; }

        [Display(Name="Nombre REPP")]
        [Required(ErrorMessage ="El nombre no puede estar vacio")]
        public string Name { set; get; }

        [DisplayName("Talla")]
        public string SizeName { set; get; }

        [Display(Name = "Color")]
        public string ColorName { set; get; }

        [Display(Name="Marca")]
        [Required(ErrorMessage = "La marca no puede esta vacia")]
        public string Brand { set; get; }


        public Color Color { set; get; }
        public Size Size { set; get; }
        public virtual ICollection<CollectionREPP> CollectionsREPPs { set; get; }
        [NotMapped]
        public string ReppName {
            get {
                return Name + "-" + ColorName;
            }
        }
    }
    
}
