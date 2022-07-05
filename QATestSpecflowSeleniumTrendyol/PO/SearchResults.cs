﻿using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using QATestSpecflowSeleniumTrendyol.Resources;

namespace QATestSpecflowSeleniumTrendyol.PO
{
    public class SearchResults
    {
        private readonly IWebDriver Driver;
        private readonly Common common;
        private readonly Actions action;

        //
        private const string FirstProductXPath = "//div[@class='prdct-cntnr-wrppr']//div[@class='p-card-wrppr'][9]";

        public SearchResults(IWebDriver webDriver)
        {
            Driver = webDriver;
            common = new Common(webDriver);
            action = new Actions(webDriver);
        }

        IWebElement FirstProductInResults => Driver.FindElement(By.XPath(FirstProductXPath));

        public void ClickFirstProduct()
        {
            common.WaitUntilElement(By.XPath(FirstProductXPath), "Exists");
            action.MoveToElement(FirstProductInResults).Perform();
            FirstProductInResults.Click();

            System.Threading.Thread.Sleep(3000);


        }
    }
}
