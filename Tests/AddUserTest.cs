using OrangeHRMtestProject.Pages;
using SeleniumExtras;
using NUnit.Framework;
using AventStack.ExtentReports;
using System;

namespace OrangeHRMtestProject.Tests
{
    public class AddUserTest : BaseClass
    {
        private LoginPage loginPage;
        private DashboardPage dashboardPage;
        private AdminPage adminPage;
        private AddUserPage addUserPage;

        [SetUp]
        public void SetUp()
        {
            // Initialize the page objects with the WebDriver instance
            loginPage = new LoginPage(driver);
            dashboardPage = new DashboardPage(driver);
            adminPage = new AdminPage(driver);
            addUserPage = new AddUserPage(driver);

            // Start logging for the current test
            extentTest = ExtentReports.CreateTest(TestContext.CurrentContext.Test.Name);

            // Login to the application using admin credentials
            loginPage.EnterUserName("Admin");
            loginPage.EnterPassword("admin123");
            loginPage.ClickLoginButton();

            // Navigate to the Admin page from the Dashboard
            dashboardPage.ClickAdminTab();

            // Navigate to the Add User page from the Admin page
            adminPage.ClickAddButton();
        }

        [Test]
        public void ValidateURLcontainSaveSystemUser()
        {
            try
            {
                extentTest.Info("Starting test: ValidateURLcontainSaveSystemUser");

                // Retrieve the current URL and assert it contains 'saveSystemUser'
                string currentUrl = driver.Url;
                Assert.That(currentUrl.Contains("saveSystemUser"), "URL does not contain the keywords 'saveSystemUser'");
               
                extentTest.Pass("URL contains the keyword 'saveSystemUser'.");
            }
            catch (Exception ex)
            {
                extentTest.Fail($"Test failed with exception: {ex.Message}");
                throw; // Re-throw the exception to ensure NUnit handles it
            }
        }

        [Test]
        public void ValidateAddUserH1IsDisplayed()
        {
            try
            {
                extentTest.Info("Starting test: ValidateAddUserH1IsDisplayed");

                // Assert that the 'Add User' H1 element is displayed on the page
                Assert.That(addUserPage.IsAddUserH1Displayed(), "Add User H1 is not displayed on the page.");

                extentTest.Pass("Add User H1 is displayed.");
            }
            catch (Exception ex)
            {
                extentTest.Fail($"Test failed with exception: {ex.Message}");
                throw; // Re-throw the exception to ensure NUnit handles it
            }
        }

        [Test]
        public void AddEmployee()
        {
            try
            {
                extentTest.Info("Starting test: AddEmployee");

                // Fill out the Add User form with employee details and save
                addUserPage.SelectUserRole("ESS");
                addUserPage.EnterEmployeeName("Omphemetse Lekaba");
                addUserPage.SelectStatus("Enabled");
                addUserPage.EnterUserName("Selenium500");
                addUserPage.EnterPassword("Selenium500");
                addUserPage.ConfirmPassword("Selenium500");
                addUserPage.Save();

                // Assert that the employee was added successfully
                Assert.That(addUserPage.IsEmployeeAddedSuccessfully(), "Employee was not added successfully.");

                extentTest.Pass("Employee was added successfully.");
            }
            catch (Exception ex)
            {
                extentTest.Fail($"Test failed with exception: {ex.Message}");
                throw; // Re-throw the exception to ensure NUnit handles it
            }
        }

    }
}
