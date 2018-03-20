using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ResourceManagerSystem.Models
{
    [DisplayName("Cargo Administrativo")]
    public class Administrative
    {
        [DisplayName("Cargo Administrativo")]
        public int AdministrativeID { set; get; }

        [Display(Name="Nombre")]
        [Required(ErrorMessage ="El nombre no puede estar vacio")]
        public string Name { set; get; }
    }
}
