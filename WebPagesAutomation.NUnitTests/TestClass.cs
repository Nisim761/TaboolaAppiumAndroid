using NUnit.Framework;
using System;
using System.Threading.Tasks;
using System.IO;
using System.Threading;
using System.Diagnostics;

using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

using WebPagesAutomation.Utils;
using WebPagesAutomation.WebPages.TaboolaApp;

namespace WebPagesAutomation.NUnitTests
{
    [TestFixture]
    public class TestClass
    {
        # region members

        private String _resourcesPath = Path.Combine(Directory.GetParent(TestContext.CurrentContext.TestDirectory).Parent.Parent.FullName, @"WebPagesAutomation\Resources");
        private AutomationController _controller = null;
        
        # endregion

        # region tests

        [SetUp]
        public void Init()
        {
            _controller = new AutomationController();
        }

        [TearDown]
        public void Terminate()
        {
            _controller.Dismiss();
            _controller = null;
        }

        [TestCase("taboolasamples-debug.apk")]
        public void TestWidgetAndFeed(String appFileName)
        {
            try
            {
                // initialize - connect with the device and install the test-app
                _controller.Initialize(_resourcesPath, appFileName);
                TaboolaApp taboola = new TaboolaApp(_controller.Driver);
                
                // Validate home screen
                if (! taboola.ValidateHomeScreen())
                {
                    throw new Exception("Test app was not launched");
                }

                // Click on first item in the menu
                taboola.ClickOnWidgetFeedScrollView();

                // Scroll down until Taboola Feed is on the screen
                taboola.ScrollDownUntilTaboolaFeedIsVisible();

                // Check there is more than 1 item
                if (taboola.NumberOfItemsInTaboolaFeed() <= 1)
                {
                    throw new Exception("There are not enough items in Taboola Feed");
                }

                // Click on the fourth item
                taboola.ClickOnItemInTaboolaFeed(4);

                // Close the item that was opened
                taboola.CloseItem();

                // Click on adchoice (the "Sponsored" word in the bottom of an item)
                taboola.ClickOnAdchoice(4);

                // Close the adchoice popup that was opened
                taboola.CloseAdchoice();

                // reached here without any exception thrown - the test passed
                Assert.Pass();
            }
            catch (Exception e)
            {
                Assert.Fail("Test " + GetCurrentMethodName(1) + " Failed" + Environment.NewLine + e.Message);
            }
            finally
            {
                _controller.Dismiss();
            }
        }

        # endregion

        # region Helper methods

        // get a method's name, for logging
        private String GetCurrentMethodName(int framesToGoBack)
        {
            StackTrace st = new StackTrace();
            StackFrame sf = st.GetFrame(framesToGoBack);
            return sf.GetMethod().Name;
        }

        # endregion
    }
}
