using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrangeHRMtestProject.Locators
{
    public class DashboardPageLocators
    {
        public static readonly By AdminTab = By.XPath("//span[@class=\"oxd-text oxd-text--span oxd-main-menu-item--name\" and text()=\"Admin\"]");
        public static readonly By WelcomeMessage = By.XPath("//p[@class=\"oxd-userdropdown-name\"]");
    }
}
