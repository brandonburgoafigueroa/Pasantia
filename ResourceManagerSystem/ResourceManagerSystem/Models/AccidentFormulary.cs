using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ResourceManagerSystem.Models
{
    public class AccidentFormulary
    {
        public int NumberOfFormulary { set; get; }
        public DateTime DateOfFullFill { set; get; }
        public string CurrentUser { set; get; }
        public Type TypeOfFormulary { set; get; }
        public Employee AffectedEmployee { set; get; }
        public string Description { set; get; }
        public ICollection<Injury> Injuries { set; get; }
        public string NatureInjury { set; get; }
        public string ObjectDescription { set; get; }
        public string MedicalDiagnostic { set; get; }
        public Employee MasterEmployee { set; get; }
        public EventLocation EventLocation { set; get; }
        public AccidentEffect AccidentEffect { set; get; }
        public ICollection<Person> Signer { set; get; }

        public enum Type
        {
            Accident, Incident, Others
        };
    }
}
