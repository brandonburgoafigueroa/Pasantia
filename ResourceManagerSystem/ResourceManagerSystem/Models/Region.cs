using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ResourceManagerSystem.Models
{
    [DisplayName("Region Administrativa")]
    public class Region
    {
        [DisplayName("Region Administrativa")]
        public int RegionID { set; get; }

        [Required(ErrorMessage = "El nombre no puede estar vacio")]
        [Display(Name="Nombre Region")]
        public string Name { set; get; }
    }
}
