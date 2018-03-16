using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ResourceManagerSystem.Models
{
    public enum Color
    {
        White, Black, Red, Orange, Yellow, Blue
    }
    public class REPP
    {

        public int ID { set; get; }
        public string Code { set; get; }
        public string Name { set; get; }
        public string Size { set; get; }
        public string Brand { set; get; }
        public Color Color { set; get; }

    }
}
