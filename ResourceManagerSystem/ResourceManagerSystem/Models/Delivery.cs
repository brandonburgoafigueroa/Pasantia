using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ResourceManagerSystem.Models
{
    public class Delivery
    {

        public int ID { set; get; }
        public REPP Reep { set; get; }
        public int Quantity { set; get; }
        public string Description { set; get; }

    }
}
