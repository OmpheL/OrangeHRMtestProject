using OpenQA.Selenium;
using OrangeHRMtestProject.Locators;
using OrangeHRMtestProject.ReusableMethod;
using System;

namespace OrangeHRMtestProject.Pages
{
    public class AddUserPage
    {
        private readonly IWebDriver driver;
        private readonly TimeSpan defaultTimeout = TimeSpan.FromSeconds(10);

        // Constructor to initialize WebDriver instance
        public AddUserPage(IWebDriver driver)
        {
            this.driver = driver;
        }

        // Method to check if the 'Add User' H1 element is displayed
        public bool IsAddUserH1Displayed(TimeSpan? timeout = null)
        {
            return ElementActions.IsVisible(driver, AddUserPageLocators.AddUserH1, timeout ?? defaultTimeout);
        }

        // Method to select a user role from the dropdown
        public void SelectUserRole(string value, TimeSpan? timeout = null)
        {
            try
            {
                ElementActions.SelectCustomDropdownByText(driver, AddUserPageLocators.UserRole, By.CssSelector(".oxd-select-text-input"), value, timeout ?? defaultTimeout);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error selecting user role: {ex.Message}");
            }
        }

        // Method to select a status from the dropdown
        public void SelectStatus(string value, TimeSpan? timeout = null)
        {
            try
            {
                ElementActions.SelectCustomDropdownByText(driver, AddUserPageLocators.Status, By.CssSelector(".oxd-select-text-input"), value, timeout ?? defaultTimeout);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error selecting status: {ex.Message}");
            }
        }

        // Method to enter the employee name
        public void EnterEmployeeName(string value, TimeSpan? timeout = null)
        {
            try
            {
                ElementActions.EnterText(driver, AddUserPageLocators.EmployeeName, value, timeout ?? defaultTimeout);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error entering employee name: {ex.Message}");
            }
        }

        // Method to enter the username
        public void EnterUserName(string value, TimeSpan? timeout = null)
        {
            try
            {
                ElementActions.EnterText(driver, AddUserPageLocators.UserName, value, timeout ?? defaultTimeout);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error entering username: {ex.Message}");
            }
        }

        // Method to enter the password
        public void EnterPassword(string value, TimeSpan? timeout = null)
        {
            try
            {
                ElementActions.EnterText(driver, AddUserPageLocators.Password, value, timeout ?? defaultTimeout);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error entering password: {ex.Message}");
            }
        }

        // Method to confirm the password
        public void ConfirmPassword(string value, TimeSpan? timeout = null)
        {
            try
            {
                ElementActions.EnterText(driver, AddUserPageLocators.ConfirmPassword, value, timeout ?? defaultTimeout);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error confirming password: {ex.Message}");
            }
        }

        // Method to click the Save button
        public void Save(TimeSpan? timeout = null)
        {
            try
            {
                ElementActions.Click(driver, AddUserPageLocators.Save, timeout ?? defaultTimeout);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error clicking Save button: {ex.Message}");
            }
        }

        // Method to check if the employee was added successfully
        public bool IsEmployeeAddedSuccessfully(TimeSpan? timeout = null)
        {
            try
            {
                // Assuming there's a success message or confirmation element to verify
                return ElementActions.IsVisible(driver, AddUserPageLocators.SuccessMessage, timeout ?? defaultTimeout);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error checking employee addition: {ex.Message}");
                return false;
            }
        }
    }
}
