using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ResourceManagerSystem.Models
{
    public class Lot
    {

        public string LotID { set; get; }
        public int ProviderID { set; get; }
        public string Description { set; get; }
        
        public Unit Unit { set; get; }

        public Provider Provider { set; get; }
        public ICollection<Delivery> Delivery { set; get; }
    }
    public enum Unit {
        [Display(Name ="Par")]
        Pair,
        [Display(Name = "Unidad")]
        Unity
    }
}
