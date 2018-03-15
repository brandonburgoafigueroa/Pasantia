using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ResourceManagerSystem.Models
{
    public class Employee : Person
    {
        public int Ci { set; get; }
        public Sex Sex { set; get; }
        public DateTime BirthDate { set; get; }
        public CivilState CivilState { set; get; }
        public TypeContrat TypeContrat { set; get; }
        public int Height { set; get; }
        public int Weight { set; get; }
        public virtual List<Grade> Grades { set; get; }
        public virtual ICollection<Inability> Inabilities { set; get; }
        public DateTime AdmissionDate { set; get; }
        public Administrative Position { set; get; }

    }
    public enum Grade
    {
        Iliterate, Basic, HighSchool, MiddleTechnician, HighTechnician, Degree
    }
    public enum Inability
    {
        Visual, Motor, Mental
    };
    public enum Sex
    {
        Female, Male
    };
    public enum CivilState
    {
        Married, Divorced, Single, Widower
    };
    public enum TypeContrat
    {
        Item, Eventual, Contrat
    };
}
