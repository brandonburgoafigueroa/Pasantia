using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ResourceManagerSystem.Models
{
    public class Region
    {
        [Key]
        public int Id { set; get; }
        public string Name { set; get; }
    }
}
