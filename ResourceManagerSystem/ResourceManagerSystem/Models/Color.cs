using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ResourceManagerSystem.Models
{
    [DisplayName("Color")]
    public class Color
    {
        [Key, Required(ErrorMessage = "El Nombre de color no puede estar vacio"), ScaffoldColumn(true)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Display(Name = "Color")]
        public string ColorName { set; get; }
    }
}
