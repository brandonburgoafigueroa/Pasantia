using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ResourceManagerSystem.Models
{
    public class Enrolment
    {
        public int EnrolmentID { set; get; }

        [Display(Name ="Curso")]
        public int CourseID { set; get; }

        [Display(Name = "Empleado")]
        public int CI { set; get; }

        [DataType(DataType.Date)]
        [Display(Name ="Fecha")]
        [Required(ErrorMessage ="La fecha no puede estar vacia")]
        public DateTime Date { set; get; }

        public Employee Employee { set; get; }
        public Course Courses { set; get; }

        
    }
}
