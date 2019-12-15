using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;

namespace Google.Search.Automation.Framework.PageObjects.SearchResults.Mappings
{
    public class SearchResultsPageMappings : BasePage
    {
        public SearchResultsPageMappings(IWebDriver driver) : base(driver)
        {
        }

        public IList<IWebElement> SearchResult_HeadersList => Helper.GetElements(By.CssSelector(".LC20lb"));
        public IList<IWebElement> SearchResult_LinksList => Helper.GetElements(By.CssSelector(".iUh30"));
        public IList<IWebElement> SearchResult_ImagesList => Helper.GetElements(By.CssSelector(".iu-card-header"));
        public IList<IWebElement> SearchResult_VideosList => Helper.GetElements(By.CssSelector(".COEoid"));
        public IWebElement GoToHomePage => Helper.GetElement(By.CssSelector("#logo"));
        public IWebElement GoToPage => Helper.GetElement(By.XPath("//a[text()=2]"));
    }
}
