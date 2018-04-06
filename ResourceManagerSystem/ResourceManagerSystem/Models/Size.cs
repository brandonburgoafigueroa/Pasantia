using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ResourceManagerSystem.Models
{
    [DisplayName("Talla")]
    public class Size
    {
        [Key, Required(ErrorMessage = "El Nombre de color no puede estar vacio"), ScaffoldColumn(true)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Display(Name = "Talla")]
        public string SizeName { set; get; }

    }
}
