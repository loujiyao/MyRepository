using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UITesting;
using System.Reflection;

namespace MyUITest
{
    public class Engine
    {
        public void Execute()
        {
            Console.WriteLine("Execute()...");
            ExecuteTestCase1();
        }

        public void ExecuteTestCase1()
        {
            Console.WriteLine("ExecuteTestCase()...");

            TestCase testCase = new TestCaseProvider().GetTestCase();

            UITestControl button = new UITestControl();


            new ControlProvider().GetButton();

            UITestControl control1 = ControlProvider.GetControl();


            object action = ActionProvider.GetAction();
            // set values
            PropertyInfo pi = action.GetType().GetProperty("UIControl");
            pi.SetValue(action, control1);

            PropertyInfo pi2 = action.GetType().GetProperty("UIControl", BindingFlags.Instance | BindingFlags.Public);

            action.GetType().GetMethod("Execute").Invoke(action, null);


        }


    }
}
