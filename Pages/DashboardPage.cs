using OpenQA.Selenium;
using OrangeHRMtestProject.Locators;
using OrangeHRMtestProject.ReusableMethod;
using SeleniumExtras.WaitHelpers;
using System;

namespace OrangeHRMtestProject.Pages
{
    public class DashboardPage
    {
        private readonly IWebDriver driver;
        private readonly TimeSpan defaultTimeout = TimeSpan.FromSeconds(10);

        // Constructor to initialize WebDriver instance
        public DashboardPage(IWebDriver driver)
        {
            this.driver = driver;
        }

        // Method to check if the Admin tab is present on the page
        public bool IsAdminTabPresent(TimeSpan? timeout = null)
        {
            return ElementActions.IsPresent(driver, DashboardPageLocators.AdminTab, timeout ?? defaultTimeout);
        }

        // Method to check if the Welcome Admin message is displayed
        public bool IsWelcomeAdminDisplayed(TimeSpan? timeout = null)
        {
            return ElementActions.IsVisible(driver, DashboardPageLocators.WelcomeMessage, timeout ?? defaultTimeout);
        }

        // Method to click the Admin tab
        public void ClickAdminTab(TimeSpan? timeout = null)
        {
            try
            {
                ElementActions.Click(driver, DashboardPageLocators.AdminTab, timeout ?? defaultTimeout);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error clicking Admin tab: {ex.Message}");
            }
        }
    }
}
