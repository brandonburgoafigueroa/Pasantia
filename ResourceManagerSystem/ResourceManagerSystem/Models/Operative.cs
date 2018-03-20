using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ResourceManagerSystem.Models
{
    [DisplayName("Cargo Operativo")]
    public class Operative
    {
        [DisplayName("Cargo Operativo")]
        public int OperativeID { set; get; }

        [DisplayName("Region Administrativa")]
        public int RegionID { set; get; }

        [DisplayName("Cargo Administrativo")]
        public int AdministrativeID { set; get; }

        [Display(Name="Nombre Cargo Operativo")]
        [Required(ErrorMessage ="El nombre no puede estar vacio")]
        public string Name { set; get; }

        public Region Region { set; get; }
        public Administrative Administrative { set; get; }
        public ICollection<CollectionREPP> CollectionRepp { set; get; }
        public ICollection<Employee> Employee { set; get; }
    }
}
