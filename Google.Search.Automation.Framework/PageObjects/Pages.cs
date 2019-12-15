using Google.Search.Automation.Framework.Core;
using Google.Search.Automation.Framework.PageObjects.Home;
using Google.Search.Automation.Framework.PageObjects.SearchResults;
using OpenQA.Selenium;

namespace Google.Search.Automation.Framework.PageObjects
{
    public class Pages : TestBase
    {
        public static HomePage Home;
        public static SearchResultsPage SearchResults;

        public static void Init(IWebDriver Driver)
        {
            Home = new HomePage(Driver);
            SearchResults = new SearchResultsPage(Driver);
        }
    }
}
