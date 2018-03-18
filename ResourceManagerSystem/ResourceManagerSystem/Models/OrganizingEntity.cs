using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ResourceManagerSystem.Models
{

    public class OrganizingEntity
    {
        public int OrganizingEntityID { set; get; }
        [Display(Name="Nombre")]
        [Required(ErrorMessage ="El nombre no puede estar vacio")]
        public string Name { set; get; }
        [Display(Name = "Entidad organizadora")]
        public TypeOfEntity TypeOfEntity { set; get; }
    }
    public enum TypeOfEntity
    {
        [Display(Name = "Empresa")]
        Bussiness,
        [Display(Name = "Persona")]
        Personal
    };
}
