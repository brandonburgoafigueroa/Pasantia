using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
namespace ResourceManagerSystem.Models
{
    public class DeliveryModelView
    {
        [Key]
        public int DeliveryModelViewID { set; get; }
        [ScaffoldColumn(false)]
        public string LotID { set; get; }
        [DisplayName("Repp")]
        [ForeignKey("Repp")]
        public int ReppID { set; get; }
        [DisplayName("Description")]
        public string Description { set; get; }
        [DisplayName("Talla")]
        public string SizeName { set; get; }
        [Display(Name = "Color")]
        public string ColorName { set; get; }
        [Display(Name = "Marca")]
        [Required(ErrorMessage = "La marca no puede esta vacia")]
        public string Brand { set; get; }
        [DisplayName("Cantidad")]
        public int Quantity { set; get; }
        public Unit Unit { set; get; }

        public Color Color { set; get; }
        public Size Size { set; get; }
        public REPP Repp { set; get; }

    }
}
