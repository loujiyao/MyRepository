using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;

namespace Demo
{
    public class ActionProvider
    {
        public static dynamic GetAction()
        {
            Assembly ass = Assembly.GetExecutingAssembly();
            dynamic obj = ass.CreateInstance("Demo.Action1", true);
            return obj;
        }
    }
}
