using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Google.Search.Automation.Framework.PageObjects.Home.Mappings;
using Google.Search.Automation.Framework.PageObjects.SearchResults;
using OpenQA.Selenium;

namespace Google.Search.Automation.Framework.PageObjects.Home
{
    public class HomePage : BasePage
    {
        public HomePageMappings Mappings;
        public HomePage(IWebDriver driver) : base(driver)
        {
            Mappings = new HomePageMappings(driver);
        }

        public void GoTo(string url)
        {
            Helper.GoToUrl(url);
        }

        public string GetTtle()
        {
           return Helper.GetTitle();
        }

        public void SearchForAndSubmitBySearchButton(string text)
        {
            Mappings.Search_Field.SendKeys(text);
            Helper.WaitForPageToLoad(By.CssSelector("input[name = 'btnK']"));
            Mappings.Search_Button.Click();
        }

        public void SearchForAndSubmitByEnterKey(string text)
        {
            Mappings.Search_Field.SendKeys(text);
            Mappings.Search_Field.SendKeys(Keys.Enter);
        }
    }
}
