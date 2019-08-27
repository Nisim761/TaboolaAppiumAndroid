using System;
using System.Collections.ObjectModel;

using OpenQA.Selenium;
using OpenQA.Selenium.Appium.Android;
using OpenQA.Selenium.Appium;

using System.Threading;

namespace WebPagesAutomation.WebPages.TaboolaApp
{
    public static class TaboolaAppMapping
    {
        // holds logic to locate elements

        // return mapping for home screen title
        public static AppiumWebElement HomeScreenTitle(AndroidDriver<AppiumWebElement> driver)
        {
            String locator = "//android.widget.TextView[@text='Taboola Sample App']";
            AppiumWebElement homeScreenTitle = null;
            try
            {
                homeScreenTitle = driver.FindElementByXPath(locator);
            }
            catch (Exception e)
            {
                throw new Exception("homeScreenTitle not found, please check locator:"
                    + Environment.NewLine + locator
                    + Environment.NewLine + "original exception: " + e.Message);
            }

            return homeScreenTitle;
        }

        // return mapping for menu item "Widget + Feed (Scroll View)"
        public static AppiumWebElement WidgetFeedScrollView(AndroidDriver<AppiumWebElement> driver)
        {
            String locator = "//android.widget.Button[@text = 'Widget + Feed (ScrollView)']";
            AppiumWebElement widgetFeedScrollViewButton = null;
            try
            {
                widgetFeedScrollViewButton = driver.FindElementByXPath(locator);
            }
            catch (Exception e)
            {
                throw new Exception("widgetFeedScrollViewButton not found, please check locator:"
                    + Environment.NewLine + locator
                    + Environment.NewLine + "original exception: " + e.Message);
            }

            return widgetFeedScrollViewButton;
        }

        // return mapping for first part of the article
        public static AppiumWebElement ArticleFirstPart(AndroidDriver<AppiumWebElement> driver)
        {
            String locator = "//android.widget.TextView[@index = 0]";
            AppiumWebElement taboolaFeedButton = null;
            try
            {
                taboolaFeedButton = driver.FindElementByXPath(locator);
            }
            catch (Exception e)
            {
                // no need to throw an exception here
                /*throw new Exception("taboolaFeedButton not found, please check locator:"
                    + Environment.NewLine + locator
                    + Environment.NewLine + "original exception: " + e.Message);*/
            }

            return taboolaFeedButton;
        }

        // return mapping for second part of the article
        public static AppiumWebElement ArticleSecondPart(AndroidDriver<AppiumWebElement> driver)
        {
            String locator = "//android.widget.TextView[@index = 2]";
            AppiumWebElement taboolaFeedButton = null;
            try
            {
                taboolaFeedButton = driver.FindElementByXPath(locator);
            }
            catch (Exception e)
            {
                // no need to throw an exception here
                /*throw new Exception("taboolaFeedButton not found, please check locator:"
                    + Environment.NewLine + locator
                    + Environment.NewLine + "original exception: " + e.Message);*/
            }

            return taboolaFeedButton;
        }

        // return mapping for "taboola feed" below the article
        public static AppiumWebElement TaboolaFeedLogo(AndroidDriver<AppiumWebElement> driver)
        {
            String locator = "//android.view.View[@resource-id = 'taboola']";
            AppiumWebElement taboolaFeedButton = null;
            try
            {
                taboolaFeedButton = driver.FindElementByXPath(locator);
            }
            catch (Exception e)
            {
                // no need to throw an exception here
                /*throw new Exception("taboolaFeedButton not found, please check locator:"
                    + Environment.NewLine + locator
                    + Environment.NewLine + "original exception: " + e.Message);*/
            }

            return taboolaFeedButton;
        }

        // return mapping of items in taboola feed
        public static AppiumWebElement ItemInTaboolaFeed(AndroidDriver<AppiumWebElement> driver, int index)
        {
            String locator = "//android.view.View[@resource-id = 'taboola-pl" + index +
                "' and @index = " + index + "]";
            AppiumWebElement itemInTaboolaFeed = null;
            
            try
            {
                itemInTaboolaFeed = driver.FindElementByXPath(locator);                
            }
            catch (Exception e)
            {
                // no need to throw an exception here
                /*throw new Exception("itemsInTaboolaFeed not found, please check locator:"
                    + Environment.NewLine + locator
                    + Environment.NewLine + "original exception: " + e.Message);*/
            }

            return itemInTaboolaFeed;
        }

        // return mapping to specific item in taboola feed
        public static AppiumWebElement ItemInTaboolaFeedButton(AndroidDriver<AppiumWebElement> driver, int index)
        {
            String locator = "//android.view.View[@resource-id = 'taboola-pl" + index + 
                "' and @index = " + index + "]";
            AppiumWebElement itemInTaboolaFeedButton = null;
            try
            {
                itemInTaboolaFeedButton = driver.FindElementByXPath(locator);
            }
            catch (Exception e)
            {
                // no need to throw an exception here
                /*throw new Exception("ItemInTaboolaFeedButton not found, please check locator:"
                    + Environment.NewLine + locator
                    + Environment.NewLine + "original exception: " + e.Message);*/
            }

            return itemInTaboolaFeedButton;
        }

        // return mapping for close item button
        public static AppiumWebElement CloseItemButton(AndroidDriver<AppiumWebElement> driver)
        {
            String locator = "//android.widget.ImageButton[@content-desc = 'Close tab']";
            AppiumWebElement closeItemButton = null;
            try
            {
                // allow time for the content to be available
                Thread.Sleep(5000);
                closeItemButton = driver.FindElementByXPath(locator);
            }
            catch (Exception e)
            {
                throw new Exception("closeItemButton not found, please check locator:"
                    + Environment.NewLine + locator
                    + Environment.NewLine + "original exception: " + e.Message);
            }

            return closeItemButton;
        }

        // return mapping of "sponsored" element
        public static AppiumWebElement AdchoiceButton(AndroidDriver<AppiumWebElement> driver, int index)
        {
            String locator = "//android.view.View[@resource-id = 'taboola-pl" + index +
                "' and @index = " + index + "]//android.view.View[@text = 'Sponsored']";
            AppiumWebElement adchoiceButton = null;
            try
            {
                adchoiceButton = driver.FindElementByXPath(locator);
            }
            catch (Exception e)
            {
                // no need to throw an exception here
                /*throw new Exception("adchoiceButton not found, please check locator:"
                    + Environment.NewLine + locator
                    + Environment.NewLine + "original exception: " + e.Message);*/
            }

            return adchoiceButton;
        }

        // return mapping for close adchoice
        public static AppiumWebElement CloseAdchoiceButton(AndroidDriver<AppiumWebElement> driver)
        {
            String locator = "//android.widget.ImageButton[contains(@resource-id , 'dismiss_button')]";
            AppiumWebElement closeChoiceButton = null;
            try
            {
                // allow time for the content to be available
                Thread.Sleep(5000);
                closeChoiceButton = driver.FindElementByXPath(locator);
            }
            catch (Exception e)
            {
                throw new Exception("closeItemButton not found, please check locator:"
                    + Environment.NewLine + locator
                    + Environment.NewLine + "original exception: " + e.Message);
            }

            return closeChoiceButton;
        }
    }
}
