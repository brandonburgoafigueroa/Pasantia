using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ResourceManagerSystem.Models
{
    public class Stock
    {
        
        public int StockID { set; get; }
        public int ReppID { set; get; }
        public int Quantity { set; get; }

        public REPP Repp { set; get; }
        
    }
}
