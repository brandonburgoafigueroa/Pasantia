using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace ResourceManagerSystem.Services
{
    public static class DisplayMembers<T>
    {
        public static string GetDisplayNameOf(T Object, string attrib)
        {
            MemberInfo property = typeof(T).GetProperty(attrib);
            var DataAnotations = property.GetCustomAttribute(typeof(DisplayAttribute)) as DisplayAttribute;
            var DataAnotationVal = "";
            if (DataAnotations != null)
            {
                 DataAnotationVal= DataAnotations.Name;
            }
            return DataAnotationVal;
        }
    }
}
