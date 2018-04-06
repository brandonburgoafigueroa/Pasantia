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

        [Display(Name = "Descripcion")]
        [Required(ErrorMessage = "La descripcion no puede estar vacia")]
        public string Description { set; get; }

    }
    
}
