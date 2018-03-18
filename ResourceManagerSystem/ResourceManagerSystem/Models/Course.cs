using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ResourceManagerSystem.Models
{
    public class Course
    {
        public int CourseID { set; get; }
        public int OrganizingEntityID { set; get; }
        [Display(Name="Nombre")]
        [Required(ErrorMessage ="El nombre no puede estar vacio")]
        public string Name { set; get; }
        [Display(Name = "Duracion (En semanas)")]
        [Required(ErrorMessage = "La duracion no puede estar vacia")]
        public int DurationWeek { set; get; }
        [Display(Name = "Descripcion")]
        [Required(ErrorMessage = "La descripcion no puede estar vacia")]
        public string Description { set; get; }
        [Display(Name = "Ubicacion")]
        [Required(ErrorMessage = "La ubicacion no puede estar vacia")]
        public string Location { set; get; }
        public AttendanceType AttendanceType { set; get; }
        [Display(Name = "¿Es un curso obligatorio?")]
        public bool IsRequired { set; get; }
        [Display(Name = "¿Es un curso externo?")]
        public bool IsExternal { set; get; }

        public OrganizingEntity OrganizingEntity { set; get; }
        public IEnumerable<Enrolment> Enrolments { set; get; }

    }
    public enum AttendanceType
    {
        [Display(Name = "Asistencia completa")]
        Complete_Assistant,
        [Display(Name = "Asistencia parcial")]
        Partial_Assistant,
        [Display(Name = "En linea")]
        Online
    }
}
