using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ResourceManagerSystem.Models
{
    public class Grade
    {
        public int ID { set; get; }
        public bool Iliterate { set; get; }
        public bool Basic { set; get; }
        public bool HighSchool { set; get; }
        public bool MiddleTechnician { set; get; }
        public bool HighTechnician { set; get; }
        public bool Degree { set; get; }


    }
}
