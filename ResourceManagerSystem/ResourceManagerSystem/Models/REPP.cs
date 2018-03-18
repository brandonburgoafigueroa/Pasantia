using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ResourceManagerSystem.Models
{
    
    public class REPP
    {
        public int ReppID { set; get; }
        [Display(Name="Nombre")]
        [Required(ErrorMessage ="El nombre no puede estar vacio")]
        public string Name { set; get; }
        [Display(Name="Talla")]
        public Size Size { set; get; }
        [Display(Name="Marca")]
        [Required(ErrorMessage = "La marca no puede esta vacia")]
        public string Brand { set; get; }
        [Display(Name="Color")]
        public Color Color { set; get; }
        public virtual ICollection<CollectionREPP> CollectionsREPPs { set; get; }
        
    }
    public enum Color
    {
        [Display(Name ="Sin color")]
        Colorless,
        [Display(Name = "Blanco")]
        White,
        [Display(Name = "Negro")]
        Black,
        [Display(Name = "Rojo")]
        Red,
        [Display(Name = "Naranja")]
        Orange,
        [Display(Name = "Amarillo")]
        Yellow,
        [Display(Name = "Azul")]
        Blue
    }
    public enum Size
    {
        [Display(Name = "Sin Tamaño")]
        without_size,
        XS,
        S,
        M,
        L,
        XL
    }
}
