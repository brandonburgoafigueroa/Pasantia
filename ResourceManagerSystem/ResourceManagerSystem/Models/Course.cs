using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ResourceManagerSystem.Models
{
    public class Course
    {
        [Key]
        public int CourseID { set; get; }

        [Display(Name = "Entidad organizadora")]
        public int OrganizingEntityID { set; get; }

        [Display(Name = "Nombre de Curso")]
        [Required(ErrorMessage = "El nombre no puede estar vacio")]
        public string Name { set; get; }

        [DisplayName("Duracion")]
        [Required(ErrorMessage = "La duracion no puede estar vacia")]
        public int Duration { set; get; }

        [DisplayName("Tipo de duracion")]
        public DurationType TypeDuration { set; get; }

        [Display(Name = "Descripcion")]
        [Required(ErrorMessage = "La descripcion no puede estar vacia")]
        public string Description { set; get; }

        [Display(Name = "Direccion")]
        [Required(ErrorMessage = "La ubicacion no puede estar vacia")]
        public string Location { set; get; }

        [Display(Name="Tipo de asistencia")]
        public AttendanceType AttendanceType { set; get; }

        [Display(Name = "¿Es un curso obligatorio?")]
        public bool IsRequired { set; get; }

        [Display(Name = "¿Es un curso externo?")]
        public bool IsExternal { set; get; }

        [Display(Name = "¿Tiene certificado?")]
        public bool HasCertified { set; get; }

        [NotMapped]
        public string DurationText {
            get {
                string Type = "";
                if (TypeDuration==DurationType.Days)
                    Type = " Dias";
                if (TypeDuration == DurationType.Weeks)
                    Type = " Meses";
                if (TypeDuration == DurationType.Month)
                    Type = " Semanas";
                return Duration + Type; 
            }
        }

        public OrganizingEntity OrganizingEntity { set; get; }
        public IEnumerable<Enrolment> Enrolments { set; get; }

    }
    public enum AttendanceType
    {
        [Display(Name = "Asistencia presencial")]
        Complete_Assistant,
        [Display(Name = "Virtual")]
        Online,
        [Display(Name = "Combinada (presencial y virtual)")]
        Combined,
        
    }
    public enum DurationType
    {
        [Display(Name ="Dias")]
        Days,
        [Display(Name = "Semanas")]
        Weeks,
        [Display(Name = "Meses")]
        Month
    }
}
