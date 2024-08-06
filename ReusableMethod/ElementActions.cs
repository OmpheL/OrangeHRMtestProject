using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using System;

namespace OrangeHRMtestProject.ReusableMethod
{
    public static class ElementActions
    {
        // Create a WebDriverWait instance for waiting
        private static WebDriverWait GetWait(IWebDriver driver, TimeSpan timeout)
        {
            return new WebDriverWait(driver, timeout);
        }

        // Enter text into an input field
        public static void EnterText(IWebDriver driver, By locator, string text, TimeSpan? timeout = null)
        {
            try
            {
                var wait = GetWait(driver, timeout ?? TimeSpan.FromSeconds(10));
                IWebElement element = wait.Until(ExpectedConditions.ElementIsVisible(locator));
                if (element.Displayed && element.Enabled)
                {
                    element.Clear();
                    element.SendKeys(text);
                }
                else
                {
                    Console.WriteLine("Element is either not displayed or not enabled.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error entering text: {ex.Message}");
            }
        }

        // Click on an element
        public static void Click(IWebDriver driver, By locator, TimeSpan? timeout = null)
        {
            try
            {
                var wait = GetWait(driver, timeout ?? TimeSpan.FromSeconds(10));
                IWebElement element = wait.Until(ExpectedConditions.ElementToBeClickable(locator));
                if (element.Displayed && element.Enabled)
                {
                    element.Click();
                }
                else
                {
                    Console.WriteLine("Element is either not displayed or not enabled.");
                }
            }
            catch (NoSuchElementException)
            {
                Console.WriteLine($"Element with locator {locator} not found.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred while clicking: {ex.Message}");
            }
        }

        // Check if an element is present in the DOM
        public static bool IsPresent(IWebDriver driver, By locator, TimeSpan? timeout = null)
        {
            try
            {
                var wait = GetWait(driver, timeout ?? TimeSpan.FromSeconds(10));
                wait.Until(driver => driver.FindElement(locator));
                return true;
            }
            catch (NoSuchElementException)
            {
                return false;
            }
        }

        // Check if an element is visible on the page
        public static bool IsVisible(IWebDriver driver, By locator, TimeSpan? timeout = null)
        {
            try
            {
                var wait = GetWait(driver, timeout ?? TimeSpan.FromSeconds(10));
                wait.Until(ExpectedConditions.ElementIsVisible(locator));
                return true;
            }
            catch (NoSuchElementException)
            {
                return false;
            }
        }

        // Select an option from a custom dropdown by text
        public static void SelectCustomDropdownByText(IWebDriver driver, By dropdownLocator, By optionLocator, string text, TimeSpan? timeout = null)
        {
            try
            {
                Click(driver, dropdownLocator, timeout);
                var wait = GetWait(driver, timeout ?? TimeSpan.FromSeconds(10));
                var optionElements = wait.Until(ExpectedConditions.PresenceOfAllElementsLocatedBy(optionLocator));

                foreach (var option in optionElements)
                {
                    if (option.Text.Contains(text))
                    {
                        option.Click();
                        break;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error selecting dropdown option: {ex.Message}");
            }
        }
    }
}
