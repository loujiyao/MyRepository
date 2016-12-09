using Microsoft.VisualStudio.TestTools.UITest.Extension;
using Microsoft.VisualStudio.TestTools.UITesting;
using Microsoft.VisualStudio.TestTools.UITesting.HtmlControls;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo
{
    public class ControlProvider
    {
        public static UITestControl GetControl() {

            var c = new BrowserWindow();
            var p =  c.SearchProperties;
            c.TechnologyName = "Web";
            c.DrawHighlight();

            return new UITestControl();
        }

        /// <summary>
        /// Gets HtmlButton control
        /// </summary>
        /// <param name="controlInfo"></param>
        /// <returns></returns>
        public dynamic GetButton()
        {
            return new HtmlButton();
        }

    }
}
