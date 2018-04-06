using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
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

        [DisplayName("Region administrativa")]
        [ForeignKey("Region")]
        [Required(ErrorMessage = "La region administrativa no puede estar vacia")]
        public int RegionID { set; get; }

        public Region Region { set; get; }
    }
}
