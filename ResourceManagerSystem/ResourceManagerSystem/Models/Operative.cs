using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ResourceManagerSystem.Models
{
    public class Operative
    {

        public int OperativeID { set; get; }
        [Display(Name = "Region")]
        [Required(ErrorMessage = "La region no puede estar vacia")]
        public int RegionID { set; get; }
        [Display(Name = "Cargo administrativo")]
        [Required(ErrorMessage = "El cargo administrativo no puede estar vacio")]
        public int AdministrativeID { set; get; }
        [Display(Name="Nombre")]
        [Required(ErrorMessage ="El nombre no puede estar vacio")]
        public string Name { set; get; }

        public Region Region { set; get; }
        public Administrative Administrative { set; get; }
        public ICollection<CollectionREPP> CollectionRepp { set; get; }
        public ICollection<Employee> Employee { set; get; }
    }
}
