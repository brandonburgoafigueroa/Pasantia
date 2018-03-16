using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ResourceManagerSystem.Models
{
    public class Operative
    {

        public int OperativeID { set; get; }
        public int RegionID { set; get; }
        public int AdministrativeID { set; get; }
        public string Code { set; get; }
        public string Name { set; get; }

        public Region Region { set; get; }
        public Administrative Administrative { set; get; }
        public ICollection<CollectionREPP> CollectionRepp { set; get; }
    }
}
