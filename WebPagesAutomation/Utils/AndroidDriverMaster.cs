using System;
using System.IO;

using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Android;
using OpenQA.Selenium.Appium.Service;
using OpenQA.Selenium.Appium.Enums;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium.Remote;

namespace WebPagesAutomation
{
    public static class AndroidDriverMaster
    {
        # region members

        private static readonly String _apkPath = Path.Combine(System.IO.Directory.GetCurrentDirectory(), "Resources");
        
        private static AndroidDriver<AppiumWebElement> _driver;
        
        # endregion

        # region methods

        // return a driver for a Android
        public static AndroidDriver<AppiumWebElement> CreateAndroidDriver(String path, String appFile)
        {
            try
            {
                AppiumLocalService _appiumLocalService;
                _appiumLocalService = AppiumLocalService.BuildDefaultService();
                _appiumLocalService.Start();
                
                DesiredCapabilities caps = new DesiredCapabilities();
                caps.SetCapability("device", "Android");
                caps.SetCapability(MobileCapabilityType.DeviceName, "Android");
                caps.SetCapability(MobileCapabilityType.PlatformName, "Android");
                caps.SetCapability(MobileCapabilityType.App, Path.Combine(path, appFile));
                caps.SetCapability(MobileCapabilityType.FullReset, true);
                
                _driver = new AndroidDriver<AppiumWebElement>(_appiumLocalService, caps);

                return _driver;
            }
            catch (Exception e)
            {
                Console.Out.WriteLine("Error creating an android-driver");
                Console.Out.WriteLine(e.Message);
                return null;
            }
        }

        # endregion
    }
}
