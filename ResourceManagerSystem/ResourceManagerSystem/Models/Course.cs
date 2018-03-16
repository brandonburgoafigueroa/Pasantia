using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ResourceManagerSystem.Models
{
    public enum AttendanceType
    {
        Complete_Assistant, Partial_Assistant, Online
    }

    public class Course
    {
        public int ID { set; get; }
        public string Name { set; get; }
        public int DurationWeek { set; get; }
        public string Description { set; get; }
        public string Location { set; get; }
        public OrganizingEntity OrganizingEntity { set; get; }
        public AttendanceType AttendanceType { set; get; }
        public bool IsRequired { set; get; }
        public bool IsExternal { set; get; }


    }
}
