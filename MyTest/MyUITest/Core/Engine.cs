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
            //ExecuteTestCase1();

            TestCase tc = new TestCase();
            tc.Id = "TestCase1";
            tc.Title = "MyFirstTestCase";
            List<Action> actions = new List<Action>();
            Action a1 = new Action();
            a1.Name = "";
            a1.ControlName = "";
            
            Param p1 = new Param();
            p1.Name = "PrintString";
            p1.Type = "String";
            p1.Value = "HelloWorld!";
            
            Param p2 = new Param();
            p2.Name = "PrintInt";
            p2.Type = "Int";
            p2.Value = "123";

            Param p3 = new Param()
            {
                Name = "",
                Type = "",
                Value = ""
            };

            a1.param.Add(p1);
            a1.param.Add(p2);
            a1.param.Add(p3);
            
            tc.actions.Add(a1);

            //TestCase.SerializeInstanceToXML(tc);
            TestCase tc2 = TestCase.CreateInstanceFromXMLFile("");


        }

        public void ExecuteTestCase1()
        {
            Console.WriteLine("ExecuteTestCase()...");

            // Get test case
            TestCase testCase = new TestCaseProvider().GetTestCase();

            //
            UITestControl button = new UITestControl();


            UITestControl control1 = new ControlProvider().GetButton();

            //UITestControl control1 = ControlProvider.GetControl();


            object action = ActionProvider.GetAction();
            // set values
            PropertyInfo pi = action.GetType().GetProperty("UIControl");
            pi.SetValue(action, control1);

            PropertyInfo pi2 = action.GetType().GetProperty("UIControl", BindingFlags.Instance | BindingFlags.Public);

            action.GetType().GetMethod("Execute").Invoke(action, null);


        }


    }
}
