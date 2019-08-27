using System;
using System.Collections.ObjectModel;

using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Android;
using OpenQA.Selenium.Appium.MultiTouch;
using OpenQA.Selenium.Appium.Interfaces;

namespace WebPagesAutomation.WebPages.TaboolaApp
{
    public class TaboolaApp
    {
        # region members

        protected AndroidDriver<AppiumWebElement> _driver; // reference to the android-driver
        
        # endregion

        # region public methods

        public TaboolaApp(AndroidDriver<AppiumWebElement> driver)
        {
            _driver = driver;
        }

        public bool ValidateHomeScreen()
        {
            try
            {
                AppiumWebElement homeScreenTitle = TaboolaAppMapping.HomeScreenTitle(_driver);
                if (null != homeScreenTitle)
                {
                    return true;
                }
            }
            catch (Exception e)
            {
                throw new Exception("ValidateHomeScreen failed" + Environment.NewLine + e.Message);
            }

            return false;
        }

        public void ClickOnWidgetFeedScrollView()
        {
            try
            {
                AppiumWebElement widgetFeedScrollViewButton = TaboolaAppMapping.WidgetFeedScrollView(_driver);
                if (null != widgetFeedScrollViewButton)
                {
                    widgetFeedScrollViewButton.Click();
                }
            }
            catch (Exception e)
            {
                throw new Exception("ClickOnWidgetFeedScrollView failed" + Environment.NewLine + e.Message);
            }
        }

        public void ScrollDownUntilTaboolaFeedIsVisible()
        {
            try
            {
                AppiumWebElement taboolaFeedButton = null;
                
                // skip first part of article
                while (null != (taboolaFeedButton = TaboolaAppMapping.ArticleFirstPart(_driver)))
                {
                    SwipeDown();
                }
                // skip second part of article
                while (null != (taboolaFeedButton = TaboolaAppMapping.ArticleSecondPart(_driver)))
                {
                    SwipeDown();
                }
                // reached the end of the text, go up a bit
                SwipeUp();
            }
            catch (Exception e)
            {
                throw new Exception("ScrollDownUntilTaboolaFeedIsVisible failed" + Environment.NewLine + e.Message);
            }
        }

        public int NumberOfItemsInTaboolaFeed()
        {
            try
            {
                int itemsInTaboolaFeed = 0;
                int swipesCounter = 0;
                AppiumWebElement itemInTaboolaFeed = null;

                try
                {
                    // only 4 iterations, as it should be enough to make sure there are more than 1 items
                    for (int index = 1; index < 5; ++index)
                    {
                        itemInTaboolaFeed = TaboolaAppMapping.ItemInTaboolaFeed(_driver, index);
                        // count current item
                        ++itemsInTaboolaFeed;
                        // swipe down
                        SwipeDown();
                        // count number of swipes
                        ++swipesCounter;
                    }

                    // scroll back up
                    while (swipesCounter > 0)
                    {
                        SwipeUp();
                        --swipesCounter;
                    }
                }
                catch (Exception e2)
                {
                }
                
                return itemsInTaboolaFeed;                
            }
            catch (Exception e)
            {
                throw new Exception("CheckNumberOfItemsInTaboolaFeed failed" + Environment.NewLine + e.Message);
            }
        }

        public void ClickOnItemInTaboolaFeed(int itemIndex)
        {
            try
            {
                AppiumWebElement itemInTaboolaFeedButton = null;
                // first - scroll to get to the 4th item
                while (null == (itemInTaboolaFeedButton = TaboolaAppMapping.ItemInTaboolaFeedButton(_driver, itemIndex)))
                {
                    SwipeDown();
                }
                // second - click on the 4th item
                itemInTaboolaFeedButton.Click();
            }
            catch (Exception e)
            {
                throw new Exception("ClickOnItemInTaboolaFeed failed" + Environment.NewLine + e.Message);
            }
        }

        public void CloseItem()
        {
            try
            {                
                AppiumWebElement closeItemButton = TaboolaAppMapping.CloseItemButton(_driver);
                if (null != closeItemButton)
                {
                    closeItemButton.Click();
                }
            }
            catch (Exception e)
            {
                throw new Exception("ClickOnWidgetFeedScrollView failed" + Environment.NewLine + e.Message);
            }
        }

        public void ClickOnAdchoice(int itemIndex)
        {
            try
            {
                AppiumWebElement adchoiceButton = null;
                // first - scroll to get to the 4th item's adchoice
                while (null == (adchoiceButton = TaboolaAppMapping.AdchoiceButton(_driver, itemIndex)))
                {
                    SwipeDown();
                }
                // second - click on the 4th item' adchoice
                adchoiceButton.Click();
            }
            catch (Exception e)
            {
                throw new Exception("ClickOnItemInTaboolaFeed failed" + Environment.NewLine + e.Message);
            }
        }

        public void CloseAdchoice()
        {
            try
            {
                AppiumWebElement closeAdchoiceButton = TaboolaAppMapping.CloseAdchoiceButton(_driver);
                if (null != closeAdchoiceButton)
                {
                    closeAdchoiceButton.Click();
                }
            }
            catch (Exception e)
            {
                throw new Exception("ClickOnWidgetFeedScrollView failed" + Environment.NewLine + e.Message);
            }
        }

        public void SwipeDown()
        {
            int xCord = 10; // arbitrary number, small enough to not click on any element
            int top = Convert.ToInt32(_driver.Manage().Window.Size.Height * 0.2);
            int bottom = Convert.ToInt32(_driver.Manage().Window.Size.Height * 0.8);
            int duration = 3000; // scroll slowly to allow the content finish loading

            _driver.Swipe(xCord, bottom, xCord, top, duration);
        }

        public void SwipeUp()
        {
            int xCord = 10; // arbitrary number, small enough to not click on any element
            int top = Convert.ToInt32(_driver.Manage().Window.Size.Height * 0.2);
            int bottom = Convert.ToInt32(_driver.Manage().Window.Size.Height * 0.8);
            int duration = 3000; // scroll slowly to allow the content finish loading

            _driver.Swipe(xCord, top, xCord, bottom, duration);
        }

        # endregion
    }
}
