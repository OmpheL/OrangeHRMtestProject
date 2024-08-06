using OrangeHRMtestProject.Pages;
using NUnit.Framework;
using AventStack.ExtentReports;

namespace OrangeHRMtestProject.Tests
{
    public class DashboardTest : BaseClass
    {
        private LoginPage loginPage;
        private DashboardPage dashboardPage;

        [SetUp]
        public void SetUp()
        {
            // Initialize the LoginPage and DashboardPage objects
            loginPage = new LoginPage(driver);
            dashboardPage = new DashboardPage(driver);

            // Start logging for the current test
            extentTest = ExtentReports.CreateTest(TestContext.CurrentContext.Test.Name);

            // Login into the Page
            loginPage.EnterUserName("Admin");
            loginPage.EnterPassword("admin123");
            loginPage.ClickLoginButton();
        }

        [Test]
        public void ValidateURLincludeDashBoard()
        {
            try
            {
                extentTest.Info("Starting test: ValidateURLincludeDashBoard");

                // Retrieve the current URL
                string currentUrl = driver.Url;
                Assert.That(currentUrl.Contains("dashboard"), "URL does not contain the keyword 'dashboard'");

                extentTest.Pass("URL contains the keyword 'dashboard'.");
            }
            catch (Exception ex)
            {
                extentTest.Fail($"Test failed with exception: {ex.Message}");
                throw; // Re-throw the exception to ensure NUnit handles it
            }
        }

        [Test]
        public void ValidateAdminTabPresence()
        {
            try
            {
                extentTest.Info("Starting test: ValidateAdminTabPresence");

                Assert.That(dashboardPage.IsAdminTabPresent(), "Admin tab is not Present");

                extentTest.Pass("Admin tab is present.");
            }
            catch (Exception ex)
            {
                extentTest.Fail($"Test failed with exception: {ex.Message}");
                throw; // Re-throw the exception to ensure NUnit handles it
            }
        }

        [Test]
        public void ValidateWelcomeMessageDisplay()
        {
            try
            {
                extentTest.Info("Starting test: ValidateWelcomeMessageDisplay");

                Assert.That(dashboardPage.IsWelcomeAdminDisplayed(), "Welcome Admin message is not displayed in the right panel");

                extentTest.Pass("Welcome Admin message is displayed.");
            }
            catch (Exception ex)
            {
                extentTest.Fail($"Test failed with exception: {ex.Message}");
                throw; // Re-throw the exception to ensure NUnit handles it
            }
        }

        [Test]
        public void NavigateToAdminPage()
        {
            try
            {
                extentTest.Info("Starting test: NavigateToAdminPage");

                dashboardPage.ClickAdminTab();

                extentTest.Pass("Navigation to Admin page was successful.");
            }
            catch (Exception ex)
            {
                extentTest.Fail($"Test failed with exception: {ex.Message}");
                throw; // Re-throw the exception to ensure NUnit handles it
            }
        }
    }
}
