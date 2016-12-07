using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Demo
{
    public static class Extensions
    {
        public static T GetPropertyValue<T>(this object source, string propertyName)
        {
            if (source == null) throw new ArgumentNullException("source");
            if (propertyName == null) throw new ArgumentNullException("propertyName");

            var property = source.GetType().GetProperty(propertyName, BindingFlags.Instance | BindingFlags.Public);
            var result = default(T);

            if (property != null)
            {
                result = (T)property.GetValue(source, null);
            }

            return result;
        }


        
    }
}
