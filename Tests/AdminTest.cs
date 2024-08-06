using OrangeHRMtestProject.Pages;
using NUnit.Framework;
using AventStack.ExtentReports;

namespace OrangeHRMtestProject.Tests
{
    public class AdminTest : BaseClass
    {
        private LoginPage loginPage;
        private DashboardPage dashboardPage;
        private AdminPage adminPage;

        [SetUp]
        public void SetUp()
        {
            // Initialize the LoginPage, DashboardPage, and AdminPage objects
            loginPage = new LoginPage(driver);
            dashboardPage = new DashboardPage(driver);
            adminPage = new AdminPage(driver);

            // Start logging for the current test
            extentTest = ExtentReports.CreateTest(TestContext.CurrentContext.Test.Name);

            // Login into the Page
            loginPage.EnterUserName("Admin");
            loginPage.EnterPassword("admin123");
            loginPage.ClickLoginButton();

            // Navigate To AdminPage
            dashboardPage.ClickAdminTab();
        }

        [Test]
        public void ValidateURLincludeadminviewSystemUsers()
        {
            try
            {
                extentTest.Info("Starting test: ValidateURLincludeadminviewSystemUsers");

                // Retrieve the current URL
                string currentUrl = driver.Url;
                Assert.That(currentUrl.Contains("admin/viewSystemUsers"), "URL does not contain the keyword 'admin/viewSystemUsers'");

                extentTest.Pass("URL contains the keyword 'admin/viewSystemUsers'.");
            }
            catch (Exception ex)
            {
                extentTest.Fail($"Test failed with exception: {ex.Message}");
                throw; // Re-throw the exception to ensure NUnit handles it
            }
        }

        [Test]
        public void ValidateAddButtonIsPresent()
        {
            try
            {
                extentTest.Info("Starting test: ValidateAddButtonIsPresent");

                Assert.That(adminPage.IsAddButtonPresent(), "Add button is not Present");

                extentTest.Pass("Add button is present.");
            }
            catch (Exception ex)
            {
                extentTest.Fail($"Test failed with exception: {ex.Message}");
                throw; // Re-throw the exception to ensure NUnit handles it
            }
        }

        [Test]
        public void ValidateDeleteButtonIsPresent()
        {
            try
            {
                extentTest.Info("Starting test: ValidateDeleteButtonIsPresent");

                Assert.That(adminPage.IsDeleteButtonPresent(), "Delete button is not Present");

                extentTest.Pass("Delete button is present.");
            }
            catch (Exception ex)
            {
                extentTest.Fail($"Test failed with exception: {ex.Message}");
                throw; // Re-throw the exception to ensure NUnit handles it
            }
        }

        [Test]
        public void ValidateSearchButtonIsPresent()
        {
            try
            {
                extentTest.Info("Starting test: ValidateSearchButtonIsPresent");

                Assert.That(adminPage.IsSearchButtonPresent(), "Search button is not Present");

                extentTest.Pass("Search button is present.");
            }
            catch (Exception ex)
            {
                extentTest.Fail($"Test failed with exception: {ex.Message}");
                throw; // Re-throw the exception to ensure NUnit handles it
            }
        }

        [Test]
        public void ValidateResetButtonIsPresent()
        {
            try
            {
                extentTest.Info("Starting test: ValidateResetButtonIsPresent");

                Assert.That(adminPage.IsResetButtonPresent(), "Reset button is not Present");

                extentTest.Pass("Reset button is present.");
            }
            catch (Exception ex)
            {
                extentTest.Fail($"Test failed with exception: {ex.Message}");
                throw; // Re-throw the exception to ensure NUnit handles it
            }
        }
    }
}
