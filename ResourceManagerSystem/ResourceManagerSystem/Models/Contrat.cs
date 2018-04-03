using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ResourceManagerSystem.Models
{
    [DisplayName("Contrato")]
    public class Contrat
    {
        [Key]
        public int ContratID { set; get; }
        [DisplayName("CI")]
        public string CI { set; get; }
        [DisplayName("Cargo operativo")]
        public int OperativeID { set;get;}
        [DisplayName("Tipo de contrato")]
        public TypeContrat TypeContrat { set; get; }
        [DisplayName("Fecha Inicio de contrato")]
        [DataType(DataType.Date)]
        public DateTime DateStart{ set; get; }
        [DisplayName("Fecha Fin de contrato ")]
        [DataType(DataType.Date)]
        public DateTime DateEnd { set; get; }

        public Employee Employee { set; get; }
        public Operative Position { set; get; }
    }
}
