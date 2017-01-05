// *************************************Microsoft IT - LPO Automation Framework*******************************************************
// File Name:   TestClassBase
// Purpose:     Base class for all Tenant Test Classes.
// Created By:  Shankar Arigela
// Created On:  July 2009
// Updates:
//  17th Sep 2009   Shankar Arigela     In the constructor, updated the Test Engine Initialization constructor calling by passing 
//                                      the assembly of the Test case to store in the RefAssemblyLookupList of Execution Engine.
//  11th Nov 2009   Shankar Arigela     Updated to use constants for App Config keys.
// **********************************************************************************************************************************

using Glider.Constants;
using Glider.Logger;
using Glider.Recorder;
using Glider.Recorder.Configuration;
using Glider.Recorder.Enums;
using Microsoft.VisualStudio.TestTools.UITesting;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;

namespace Glider
{
    /// <summary>
    /// Base test class from which all the Tenant/Client's Test Classes need to inherit from. 
    /// The Tenant's TestClassInitialize() method should call this Base Class's TestClassInitialize() method.
    /// The same is true for TestClassCleanup() as well.
    /// </summary>
    [CodedUITest]
    public class TestClassBase
    {
        static TestClassBase()
        {
            try
            {
                RecorderConfiguration = ConfigurationManager.GetSection("Recorder") as RecorderSection;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Glider.Recorder.Configuration is not loaded.");
                Console.WriteLine("Exception: " + ex.Message);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public TestClassBase()
        {
            #region Initialization
            TestEngine = new ExecutionEngine(System.Reflection.Assembly.GetAssembly(this.GetType()));
            #endregion

        }

        private TestContext _testContext;
        private string _testCaseXmlFullName;
        private ExecutionEngine _testEngine;
        public static RecorderSection RecorderConfiguration { get; private set; }

        #region P R O P E R T I E S
        /// <summary>
        ///Gets or sets the test context which provides information about and functionality for the current test run.
        ///</summary>
        public TestContext TestContext
        {
            get
            {
                return _testContext;
            }
            set
            {
                _testEngine.TestContext = value;
                _testContext = value;
            }
        }
        /// <summary>
        /// Gets or Sets the full file name of the Test case XML.
        /// </summary>
        public string TestCaseXMLFullName
        {
            get
            {
                return _testCaseXmlFullName;
            }
            set
            {
                _testCaseXmlFullName = value;
            }
        }
        /// <summary>
        /// Gets or sets the instance of the Execution Engine of the LPO Automation Framework.
        /// </summary>
        public ExecutionEngine TestEngine
        {
            get { return _testEngine; }
            set { _testEngine = value; }
        }

        #endregion


        // Use ClassInitialize to run code before running the first test in the class
        /// <summary>
        /// Is used to run code before running the first test case in the Class. 
        /// This triggers Logger instance that would be used for logging purpose.
        /// </summary>
        /// <param name="testContext">The default test context of the execution</param>
        [ClassInitialize()]
        public static void TestClassInitialize(TestContext testContext)
        {
            GenericConstants.logger = new Logger.Logger();

            GenericConstants.logger.BeginTestSuite(GenericConstants.ResultFileName);
        }


        /// <summary>
        /// Runs after the end of the all test cases execution. Here we close the logger instance.
        /// </summary>
        [ClassCleanup()]
        public static void TestClassCleanup()
        {
            GenericConstants.logger.EndTestSuite();
        }

        /// <summary>
        /// Runs before running each test case. 
        /// Includes the test case begin trigger for the Logger.
        /// </summary>
        [TestInitialize()]
        public void TestInitialize()
        {

            TestEngine.ActionsLibraryEngine.UIControlsPool.Clear();

            if (TestContext != null)
            {
                Int64 id;
                if (!TestContext.Properties.Contains("WorkItem") && Int64.TryParse(TestContext.Properties["TestName"].ToString().Split('_').Last(), out id))
                {
                    if (TestContext.Properties.Contains("WorkItem"))
                    {
                        TestContext.Properties.Add("WorkItem", id);
                    }
                    else
                    {
                        TestContext.Properties["WorkItem"] = id;
                    }
                }
            }

            GenericConstants.logger.TestContext = TestContext;

            GenericConstants.logger.BeginTestCase();

            if (TestContext != null && (RecorderConfiguration != null && RecorderConfiguration.Enabled))
            {
                var index = 1;
                if (TestContext.DataRow != null)
                    index = TestContext.DataRow.Table.Rows.IndexOf(TestContext.DataRow) + index;

                var fileName = Path.Combine((RecorderConfiguration.StorageMode == RecordingStorageMode.Default ? TestContext.TestResultsDirectory : Path.GetFullPath(RecorderConfiguration.StoragePath)), string.Format("TestCaseVideo{0}.wmv", index));

                ScreenRecorder.Start(fileName);
            }
        }

        /// <summary>
        /// Runs after execution of each test case.
        /// Includes test case logging end trigger of logger.
        /// </summary>
        [TestCleanup()]
        public void TestCleanUp()
        {
            if (TestContext != null)
            {
                if (RecorderConfiguration != null && RecorderConfiguration.TakeScreenClip)
                {
                    try
                    {
                        var image = ScreenCapture.CaptureImage();

                        if (image != null)
                        {
                            var index = 1;
                            if (TestContext.DataRow != null)
                                index = TestContext.DataRow.Table.Rows.IndexOf(TestContext.DataRow) + index;

                            var fileName = Path.Combine((RecorderConfiguration.StorageMode == RecordingStorageMode.Default ? TestContext.TestResultsDirectory : Path.GetFullPath(RecorderConfiguration.StoragePath)), string.Format("ScreenShot{0}.jpeg", index));

                            image.Save(fileName);

                            TestContext.AddResultFile(fileName);
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                }

                if (RecorderConfiguration != null && RecorderConfiguration.Enabled)
                {
                    ScreenRecorder.Stop();

                    TestContext.AddResultFile(ScreenRecorder.FileName);

                    if (!TestContext.Properties.Contains("HasVideo"))
                        TestContext.Properties.Add("HasVideo", true);
                }
                else
                {
                    if (!TestContext.Properties.Contains("HasVideo"))
                        TestContext.Properties.Add("HasVideo", false);
                }
            }

            GenericConstants.logger.EndTestCase();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="actions"></param>
        /// <param name="componentName"></param>
        /// <param name="controlName"></param>
        /// <param name="value"></param>
        /// <param name="name"></param>
        /// <param name="returnRef"></param>
        /// <param name="overrideProperty"></param>
        /// <param name="overrideValue"></param>
        /// <returns></returns>
        protected virtual Action AddActionWithComponentName(List<Action> actions, string componentName, string controlName, string value = "", string name = "", string returnRef = "", string overrideProperty = "", string overrideValue = "")
        {
            Action action = new Action { ComponentName = componentName, ControlName = controlName, Value = value, Name = name, ReturnRef = returnRef, OverrideProperty = overrideProperty, OverrideValue = overrideValue };

            actions.Add(action);

            return action;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="actions"></param>
        /// <param name="controlName"></param>
        /// <param name="value"></param>
        /// <param name="name"></param>
        /// <param name="returnRef"></param>
        /// <param name="overrideProperty"></param>
        /// <param name="overrideValue"></param>
        /// <returns></returns>
        protected virtual Action AddAction(List<Action> actions, string controlName, string value = "", string name = "", string returnRef = "", string overrideProperty = "", string overrideValue = "")
        {
            Action action = new Action { ControlName = controlName, Value = value, Name = name, ReturnRef = returnRef, OverrideProperty = overrideProperty, OverrideValue = overrideValue };

            actions.Add(action);

            return action;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="className"></param>
        /// <param name="methodName"></param>
        /// <param name="actions"></param>
        /// <param name="parameters"></param>
        /// <param name="returnref"></param>
        /// <returns></returns>
        protected virtual Action AddFunctionCall(string className, string methodName, List<Action> actions = null, List<Param> parameters = null, string returnref = null)
        {
            Action action = new Action { ComponentName = className, Name = methodName, ReturnRef = returnref, param = parameters ?? new List<Param>() };

            if (actions != null)
                actions.Add(action);

            return action;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        protected virtual string GetReturnRefFor(string name)
        {
            return "returnref:" + name;
        }
    }
}
