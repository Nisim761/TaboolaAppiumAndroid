using System;
using System.Diagnostics;

using OpenQA.Selenium;

using OpenQA.Selenium.Appium.Android;
using OpenQA.Selenium.Appium;

namespace WebPagesAutomation.Utils
{
    public class AutomationController
    {
        # region members

        private AndroidDriver<AppiumWebElement> _driver = null;
        
        # endregion

        # region properties

        public AndroidDriver<AppiumWebElement> Driver
        {
            get { return _driver; }
        }

        # endregion

        # region public methods

        public void Initialize(String resourcesPath, String apk)
        {
            // create appium-driver object
            _driver = AndroidDriverMaster.CreateAndroidDriver(resourcesPath, apk);
        }

        public void Dismiss()
        {
            if (null != _driver)
            {
                _driver.Quit();
            }
            _driver = null;
        }

        public void LoadPage(String url)
        {
            _driver.Navigate().GoToUrl(url);
        }
        
        # endregion

        # region helper methods

        // get a method's name, for logging
        private String GetCurrentMethodName()
        {
            StackTrace st = new StackTrace();
            StackFrame sf = st.GetFrame(1);
            return sf.GetMethod().Name;
        }

        # endregion
    }
}
