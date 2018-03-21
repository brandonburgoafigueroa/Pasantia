using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ResourceManagerSystem.Models
{
    public class Lot
    {

        public string LotID { set; get; }
        public string Description { set; get; }
        public int ProviderID { set; get; }

        public Provider Provider { set; get; }

        public virtual ICollection<Delivery> Delivery { set; get; }
    }
}
