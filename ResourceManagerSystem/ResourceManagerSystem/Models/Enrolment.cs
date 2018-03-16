using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ResourceManagerSystem.Models
{
    public class Enrolment
    {
        public int ID { set; get; }
        public virtual ICollection<Employee> Employees { set; get; }
        public virtual ICollection<Course> Courses { set; get; }
        public DateTime Date { set; get; }
    }
}
