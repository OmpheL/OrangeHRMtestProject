using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrangeHRMtestProject.Locators
{
    public class AdminPageLocators
    {
        public static readonly By AddButton = By.XPath("//button[@class=\"oxd-button oxd-button--medium oxd-button--secondary\"]");
        public static readonly By DeleteButton = By.XPath("//button[@class='oxd-icon-button oxd-table-cell-action-space']");
        public static readonly By SearchButton = By.XPath("//button[@class=\"oxd-button oxd-button--medium oxd-button--secondary orangehrm-left-space\"]");
        public static readonly By ResetButton = By.XPath("//button[@class=\"oxd-button oxd-button--medium oxd-button--ghost\"]");
    }
}
