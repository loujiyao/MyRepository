using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UITesting;
using Microsoft.VisualStudio.TestTools.UITesting.HtmlControls;

namespace Demo
{
    public class ControlProvider
    {
        public static UITestControl GetControl() {
            
            //return new UITestControl();
            return new HtmlButton();
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
