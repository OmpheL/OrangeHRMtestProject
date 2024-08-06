using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrangeHRMtestProject.Locators
{
    public class LoginPageLocators
    {
        public static readonly By UserName = By.XPath("//input[@name=\"username\"]");
        public static readonly By Password = By.XPath("//input[@name=\"password\"]");
        public static readonly By LoginButton = By.XPath("//button[@type=\"submit\"]");

    }
}
