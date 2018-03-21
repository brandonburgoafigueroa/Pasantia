using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ResourceManagerSystem.Models
{
    public class EventLocation
    {
        public int EventLocationID { set; get; }
        public DateTime Date { set; get; }
        public Building Building { set; get; }
        public string OutsideAsociationAddress { set; get; }
    }
}
