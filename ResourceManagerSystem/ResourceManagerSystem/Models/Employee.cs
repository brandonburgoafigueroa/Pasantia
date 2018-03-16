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
        public DateTime AdmissionDate { set; get; }
        //Grade
        public bool Iliterate { set; get; }
        public bool Basic { set; get; }
        public bool HighSchool { set; get; }
        public bool MiddleTechnician { set; get; }
        public bool HighTechnician { set; get; }
        public bool Degree { set; get; }
        //--EndGrade
        //Inabilities
        public bool Visual { set; get; }
        public bool Motor { set; get; }
        public bool Mental { set; get; }
        //--EndInabilities

        public Administrative Position { set; get; }
    }
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
