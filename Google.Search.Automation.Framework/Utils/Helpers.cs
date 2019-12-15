using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using ExpectedConditions = SeleniumExtras.WaitHelpers.ExpectedConditions;

namespace Google.Search.Automation.Framework.Utils
{
   public class Helpers
    {
        public IWebDriver _driver { get; set; }
        public Helpers(IWebDriver driver)
        {
            _driver = driver;
        }
        
        public void WaitForPageToLoad(By name, int duration = 10)
        {
            var Wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(duration));
            Wait.Until(ExpectedConditions.ElementIsVisible(name));
        }

        public void WaitForTextToBePresent(IWebElement element, string text, int duration = 10)
        {
            var Wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(duration));
            Wait.Until(ExpectedConditions.TextToBePresentInElement(element, text));
        }

        public IWebElement GetElement(By locator)
        {

            return _driver.FindElement(locator);
        }

        public List<IWebElement> GetElements(By locator)
        {

            return _driver.FindElements(locator).ToList();
        }

        public string GetCurrentUrl()
        {
            return _driver.Url;
        }

        public string GetTitle()
        {
            return _driver.Title;
        }

        public void GoToUrl(string url)
        {
            _driver.Navigate().GoToUrl(url);
        }

        public string GetText(IWebElement Element)
        {
            return Element.Text;
        }
    }
}
