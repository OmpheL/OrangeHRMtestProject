using OpenQA.Selenium;
using OrangeHRMtestProject.Locators;
using OrangeHRMtestProject.ReusableMethod;
using SeleniumExtras.WaitHelpers;
using System;

namespace OrangeHRMtestProject.Pages
{
    public class AdminPage
    {
        private readonly IWebDriver driver;
        private readonly TimeSpan defaultTimeout = TimeSpan.FromSeconds(10);

        // Constructor to initialize WebDriver instance
        public AdminPage(IWebDriver driver)
        {
            this.driver = driver;
        }

        // Method to check if the Add button is present on the page
        public bool IsAddButtonPresent(TimeSpan? timeout = null)
        {
            return ElementActions.IsPresent(driver, AdminPageLocators.AddButton, timeout ?? defaultTimeout);
        }

        // Method to check if the Delete button is present on the page
        public bool IsDeleteButtonPresent(TimeSpan? timeout = null)
        {
            return ElementActions.IsPresent(driver, AdminPageLocators.DeleteButton, timeout ?? defaultTimeout);
        }

        // Method to check if the Search button is present on the page
        public bool IsSearchButtonPresent(TimeSpan? timeout = null)
        {
            return ElementActions.IsPresent(driver, AdminPageLocators.SearchButton, timeout ?? defaultTimeout);
        }

        // Method to check if the Reset button is present on the page
        public bool IsResetButtonPresent(TimeSpan? timeout = null)
        {
            return ElementActions.IsPresent(driver, AdminPageLocators.ResetButton, timeout ?? defaultTimeout);
        }

        // Method to click the Add button
        public void ClickAddButton(TimeSpan? timeout = null)
        {
            try
            {
                ElementActions.Click(driver, AdminPageLocators.AddButton, timeout ?? defaultTimeout);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error clicking Add button: {ex.Message}");
            }
        }
    }
}
