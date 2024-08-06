using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace OrangeHRMtestProject.Locators
{
    public class AddUserPageLocators
    {
        public static readonly By AddUserH1 = By.XPath("//h1[text()='Add User']");
        public static readonly By UserRole = By.XPath("(//div[@class='oxd-select-text-input'])[1]");
        public static readonly By EmployeeName = By.XPath("//input[@placeholder=\"Type for hints...\"]");
        public static readonly By Status = By.XPath("(//div[@class='oxd-select-text-input'])[2]");
        public static readonly By UserName = By.XPath("(//input[@class=\"oxd-input oxd-input--active\"])[2]");
        public static readonly By Password = By.XPath("(//input[@type=\"password\"])[1]");
        public static readonly By ConfirmPassword = By.XPath("(//input[@type=\"password\"])[2]");
        public static readonly By Save = By.XPath("//button[text()=' Save ']");
        public static readonly By SuccessMessage = By.XPath("//div[contains(text(),'Successfully Added')]");  //This is not an actual locator
    }
}
