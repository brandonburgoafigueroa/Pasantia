using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ResourceManagerSystem.Models
{
    public class Region
    {
        public int RegionID { set; get; }
        [Required(ErrorMessage = "El nombre no puede estar vacio")]
        [Display(Name="Nombre")]
        public string Name { set; get; }
    }
}
