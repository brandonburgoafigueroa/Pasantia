using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ResourceManagerSystem.Models
{
    public class Stock
    {
        
        public int StockID { set; get; }
        [ForeignKey("REPP")]
        public int ReppID { set; get; }
        public int Quantity { set; get; }
        [ForeignKey("Color")]
        public string ColorName { set; get; }
        [ForeignKey("Size")]
        public string SizeName { set; get; }

        public REPP Repp { set; get; }
        public Color Color { set; get; }
        public Size Size { set; get; }
        
    }
}
