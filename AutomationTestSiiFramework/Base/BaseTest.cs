﻿using AutomationTestSiiFramework.Extensions;
using LLibrary;
using NUnit.Framework;
using OpenQA.Selenium;

namespace AutomationTestSiiFramework.Base
{
    [TestFixture]
    // [AllureNUnit]
    public class BaseTest
    {
        [SetUp]
        public void Setup()
        {
            var driverFactory = new WebDriverFactory();
            var logger = new L();
            Driver = TestSettings.ConfigurationJson.BrowserType == "local"
                ? driverFactory.GetWebDriver(logger)
                : driverFactory.GetRemoteDriver();
            Driver.Manage().Window.Maximize();
            Driver.Open(TestSettings.ConfigurationJson.ShopAppUrl);
        }

        [TearDown]
        public void TearDown()
        {
            Driver.Quit();
        }

        protected IWebDriver Driver { get; set; }
    }
}