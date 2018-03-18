using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ResourceManagerSystem.Models
{
    public class Employee : Person
    {
        [Display(Name = "Cargo Operativo")]
        [Required(ErrorMessage = "El cargo operativo no pude estar vacio")]
        public int OperativeID { set; get; }
        [Display(Name = "Genero")]
        public Sex Sex { set; get; }
        [Display(Name = "Fecha de nacimiento")]
        [Required(ErrorMessage ="La fecha de nacimiento no puede estar vacia")]
        public DateTime BirthDate { set; get; }
        [Display(Name = "Estado civil")]
        public CivilState CivilState { set; get; }
        [Display(Name = "Tipo de contrato")]
        public TypeContrat TypeContrat { set; get; }
        [Display(Name = "Altura")]
        [Required(ErrorMessage = "La altura no puede estar vacia")]
        public int Height { set; get; }
        [Display(Name = "Peso")]
        [Required(ErrorMessage = "El peso no puede estar vacio")]
        public int Weight { set; get; }
        [Display(Name = "Fecha de admisión")]
        [Required(ErrorMessage = "La fecha de admisión no puede estar vacia")]
        public DateTime AdmissionDate { set; get; }
        //Grade
        [Display(Name = "Analfabeta")]
        public bool Illiterate { set; get; }
        [Display(Name = "Nivel Basico")]
        public bool Basic { set; get; }
        [Display(Name = "Universidad")]
        public bool HighSchool { set; get; }
        [Display(Name = "Tecnico medio")]
        public bool MiddleTechnician { set; get; }
        [Display(Name = "-----")]
        public bool HighTechnician { set; get; }
        [Display(Name = "Licenciatura")]
        public bool Degree { set; get; }
        //--EndGrade
        //Inabilities
        [Display(Name = "Visual")]
        public bool Visual { set; get; }
        [Display(Name = "Motor")]
        public bool Motor { set; get; }
        [Display(Name = "Mental")]
        public bool Mental { set; get; }
        //--EndInabilities

        public Operative Position { set; get; }
        public ICollection<Enrolment> Enrolment { set; get; }
  
    }
    public enum Sex
    {
        [Display(Name = "Femenino")]
        Female,
        [Display(Name = "Masculino")]
        Male
    };
    public enum CivilState
    {
        [Display(Name = "Casado(a)")]
        Married,
        [Display(Name = "Divorciado(a)")]
        Divorced,
        [Display(Name = "Soltero(a)")]
        Single,
        [Display(Name = "Divorciado(a)")]
        Widower

    };
    public enum TypeContrat
    {
        [Display(Name = "Item")]
        Item,
        [Display(Name = "Eventual")]
        Eventual,
        [Display(Name = "Contrato")]
        Contrat
    };
}
