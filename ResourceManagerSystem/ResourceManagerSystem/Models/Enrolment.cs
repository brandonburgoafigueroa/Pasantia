using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ResourceManagerSystem.Models
{
    public class Enrolment
    {
        [Key]
        [Display(Name ="Curso")]
        public int CourseID { set; get; }
        [Key]
        [Display(Name = "Empleado")]
        public int CI { set; get; }

        [DataType(DataType.Date)]
        [Display(Name ="Fecha")]
        [Required(ErrorMessage ="La fecha no puede estar vacia")]
        public DateTime Date { set; get; }

        [Display(Name ="Empleado")]
        public Employee Employee { set; get; }
        [Display(Name = "Curso")]
        public Course Courses { set; get; }

        
    }
}
