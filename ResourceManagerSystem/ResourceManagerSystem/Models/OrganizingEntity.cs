using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ResourceManagerSystem.Models
{
    public enum TypeOfEntity
    {
        Bussiness, Personal
    };
    public class OrganizingEntity
    {
        public int Id { set; get; }
        public string Name { set; get; }
        public TypeOfEntity TypeOfEntity { set; get; }
    }
}
