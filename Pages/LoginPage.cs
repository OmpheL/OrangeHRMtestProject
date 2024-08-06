using OpenQA.Selenium;
using OrangeHRMtestProject.Locators;
using OrangeHRMtestProject.ReusableMethod;
using SeleniumExtras.WaitHelpers;
using System;

namespace OrangeHRMtestProject.Pages
{
    public class LoginPage
    {
        private readonly IWebDriver driver;
        private readonly TimeSpan defaultTimeout = TimeSpan.FromSeconds(10);

        // Constructor to initialize WebDriver instance
        public LoginPage(IWebDriver driver)
        {
            this.driver = driver;
        }

        // Method to enter username into the username field
        public void EnterUserName(string value, TimeSpan? timeout = null)
        {
            try
            {
                ElementActions.EnterText(driver, LoginPageLocators.UserName, value, timeout ?? defaultTimeout);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error entering username: {ex.Message}");
            }
        }

        // Method to enter password into the password field
        public void EnterPassword(string value, TimeSpan? timeout = null)
        {
            try
            {
                ElementActions.EnterText(driver, LoginPageLocators.Password, value, timeout ?? defaultTimeout);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error entering password: {ex.Message}");
            }
        }

        // Method to click the login button
        public void ClickLoginButton(TimeSpan? timeout = null)
        {
            try
            {
                ElementActions.Click(driver, LoginPageLocators.LoginButton, timeout ?? defaultTimeout);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error clicking login button: {ex.Message}");
            }
        }
    }
}
