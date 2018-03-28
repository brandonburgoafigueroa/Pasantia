using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ResourceManagerSystem.Models
{
    public class Contrat
    {
        [Key]
        public int ContratID { set; get; }
        public string CI { set; get; }
        public int OperativeID { set;get;}
        public TypeContrat TypeContrat { set; get; }
        public DateTime DateStart{ set; get; }
        public DateTime DateEnd { set; get; }

        public Employee Employee { set; get; }
        public Operative Position { set; get; }
    }
}
