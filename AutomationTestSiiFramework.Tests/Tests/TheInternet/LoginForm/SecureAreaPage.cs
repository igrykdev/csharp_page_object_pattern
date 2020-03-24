﻿using AutomationTestSiiFramework.Base;
using AutomationTestSiiFramework.Extensions;
using AutomationTestSiiFramework.Tests.Extensions;
using OpenQA.Selenium;

namespace AutomationTestSiiFramework.Tests.Tests.TheInternet.LoginForm
{
    public class SecureAreaPage : BasePage
    {
        public SecureAreaPage(IWebDriver driver) : base(driver)
        {
        }

        private IWebElement LogoutButton => Driver.FindElement(By.CssSelector(".icon-signout"));
        private IWebElement SuccessMessageElement => Driver.FindElement(By.CssSelector(".success"));
        private IWebElement InvalidPasswordMessageElement => Driver.FindElement(By.CssSelector(".error"));

        public string SuccessMessage => SuccessMessageElement.GetAttribute("innerText").RemoveNewLines();

        public string InvalidPasswordMessage =>
            InvalidPasswordMessageElement.GetAttribute("innerText").RemoveNewLines();

        public SecureAreaPage Logout()
        {
            Driver.ClickOnElement(LogoutButton);
            return this;
        }
    }
}