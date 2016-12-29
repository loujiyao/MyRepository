using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UITesting;

namespace MyUITest
{
    public class Action1
    {
        public UITestControl UIControl { get; set; }

        public void Execute()
        {
            Console.WriteLine("Action1.Execute()...");
            if (null != UIControl)
            {
                Console.WriteLine("UIControl is not null.");
            }
            else
            {
                Console.WriteLine("UIControl is null.");
            }

        }
    }
}
