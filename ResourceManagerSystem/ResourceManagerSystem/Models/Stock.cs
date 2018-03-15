using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ResourceManagerSystem.Models
{
    public class Stock
    {
        [Key]
        public int Id { set; get; }
        public REPP Repp { set; get; }
        public int Inventory { set; get; }
    }
}
