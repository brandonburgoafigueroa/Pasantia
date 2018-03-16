using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ResourceManagerSystem.Models
{
    public abstract class Person
    {
        [Key]
        public int PersonID { set; get; }
        public string Name { set; get; }
        public string FirstName { set; get; }
        public string LastName { set; get; }
        public int Phone { set; get; }
        public string Email { set; get; }

    }
}
