using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ResourceManagerSystem.Models
{
    public class Provider
    {

        public int ID { set; get; }
        public int Code { set; get; }
        public string Name { set; get; }
        public string Address { set; get; }
        public string City { set; get; }
        public Person Contact { set; get; }

    }
}
