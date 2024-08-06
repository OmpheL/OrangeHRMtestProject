using OrangeHRMtestProject.Pages;
using OrangeHRMtestProject.Locators;
using NUnit.Framework;
using AventStack.ExtentReports;
using OrangeHRMtestProject.Utilities;

namespace OrangeHRMtestProject.Tests
{
    public class LoginTest : BaseClass
    {
        private LoginPage loginPage;

        [SetUp]
        public void SetUp()
        {
            // Initialize the LoginPage and DashboardPage objects
            loginPage = new LoginPage(driver);

            // Start logging for the current test
            extentTest = ExtentReports.CreateTest(TestContext.CurrentContext.Test.Name);
        }

        [Test]
        public void ValidatePageTitle()
        {
            try
            {
                extentTest.Info("Starting test: ValidatePageTitle");

                // Assert that the page title is "OrangeHRM"
                string pageTitle = driver.Title;
                Assert.That(pageTitle, Is.EqualTo("OrangeHRM"), "The page title is not 'OrangeHRM'.");

                extentTest.Pass("Page title validated successfully.");
            }
            catch (Exception ex)
            {
                extentTest.Fail($"Test failed with exception: {ex.Message}");
                throw; // Re-throw the exception to ensure NUnit handles it
            }
        }

        [Test]
        public void UserShouldBeAbleToLogin()
        {
            try
            {
                extentTest.Info("Starting test: UserShouldBeAbleToLogin");

                // Enter username
                loginPage.EnterUserName(TestData.GetUserName());

                // Enter password
                loginPage.EnterPassword(TestData.GetPassword());

                // Click login button
                loginPage.ClickLoginButton();

                extentTest.Pass("User logged in successfully.");
            }
            catch (Exception ex)
            {
                extentTest.Fail($"Test failed with exception: {ex.Message}");
                throw; // Re-throw the exception to ensure NUnit handles it
            }
        }
    }
}
