using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ResourceManagerSystem.Models
{
    public class Delivery
    {

        public int DeliveryID { set; get; }
        public int ReppID { set; get; }
        public int Quantity { set; get; }
        public string Description { set; get; }

        public REPP Reep { set; get; }
        public ICollection<LotDelivery> LotDelivery { set; get; }
    }
}
