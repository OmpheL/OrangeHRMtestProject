﻿using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;
using AventStack.ExtentReports.Reporter.Config;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OrangeHRMtestProject.Utilities;
using System;
using System.IO;

namespace OrangeHRMtestProject
{
    public class BaseClass
    {
        protected static IWebDriver driver; // WebDriver instance shared across tests
        private static ExtentReports? extentReports; // ExtentReports instance for generating and managing test reports
        protected ExtentTest extentTest; // ExtentTest instance to log results for each test
        private static ExtentSparkReporter sparkReporter; // SparkReporter to format the report in HTML

        // Property to get or create an instance of ExtentReports
        protected static ExtentReports ExtentReports
        {
            get => extentReports ??= ReportManager.GetExtentReports();
            set => extentReports = value;
        }

        [OneTimeSetUp]
        public void OneTimeSetUp()
        {
            // Executes once before any tests are run
            try
            {
                // Define the path where ExtentReports will be saved
                string reportDirectory = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "ExtentReports");

                // Create the directory if it does not already exist
                if (!Directory.Exists(reportDirectory))
                {
                    Directory.CreateDirectory(reportDirectory);
                }

                // Initialize ExtentReports instance for test reporting
                ExtentReports = ReportManager.GetExtentReports();
                string reportPath = Path.Combine(reportDirectory, "Spark.html");

                // Configure the SparkReporter with report details
                sparkReporter = new ExtentSparkReporter(reportPath)
                {
                    Config =
                    {
                        DocumentTitle = "Automation Test Report", // Title of the HTML report
                        ReportName = "OrangeHRM Test Report", // Name of the report
                        Theme = Theme.Standard // Report theme
                    }
                };
                ExtentReports.AttachReporter(sparkReporter); // Attach the reporter to ExtentReports
            }
            catch (Exception ex)
            {
                // Log the error and rethrow to halt execution if setup fails
                Console.WriteLine($"Error during OneTimeSetUp: {ex.Message}");
                throw;
            }
        }

        [SetUp]
        public void Init()
        {
            // Runs before each test to prepare the test environment
            try
            {
                // Set up ChromeDriver with desired options
                ChromeOptions options = new ChromeOptions();
                options.AddArgument("--start-maximized"); // Maximize the browser window
                driver = new ChromeDriver(options);
                driver.Navigate().GoToUrl("https://opensource-demo.orangehrmlive.com/"); // Navigate to the application under test
                driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10); // Set an implicit wait for element loading

                // Create a new test entry in the ExtentReports
                extentTest = ExtentReports.CreateTest(TestContext.CurrentContext.Test.Name);
            }
            catch (Exception ex)
            {
                // Log the error and rethrow to halt execution if setup fails
                Console.WriteLine($"Error during SetUp: {ex.Message}");
                throw;
            }
        }

        [TearDown]
        public void TearDown()
        {
            // Runs after each test to finalize the test results
            try
            {
                // Check test status and log result in ExtentReports
                if (TestContext.CurrentContext.Result.Outcome.Status == NUnit.Framework.Interfaces.TestStatus.Failed)
                {
                    extentTest.Fail("Test failed: " + TestContext.CurrentContext.Result.Message); // Log failure with message
                }
                else
                {
                    extentTest.Pass("Test passed"); // Log success
                }
            }
            catch (Exception ex)
            {
                // Log the error and rethrow if teardown fails
                Console.WriteLine($"Error during TearDown: {ex.Message}");
                throw;
            }
            finally
            {
                // Ensure WebDriver is properly quit and disposed
                driver?.Quit();
                driver?.Dispose();
            }
        }

        [OneTimeTearDown]
        public void OneTimeTearDown()
        {
            // Executes once after all tests are run to finalize reporting
            try
            {
                // Flush the ExtentReports to write the results to the file
                ReportManager.FlushReports();
            }
            catch (Exception ex)
            {
                // Log the error and rethrow if flushing fails
                Console.WriteLine($"Error during OneTimeTearDown: {ex.Message}");
                throw;
            }
        }
    }
}
