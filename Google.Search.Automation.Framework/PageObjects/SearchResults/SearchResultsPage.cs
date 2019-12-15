using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Google.Search.Automation.Framework.PageObjects.SearchResults.Mappings;
using OpenQA.Selenium;
using System.Web;

namespace Google.Search.Automation.Framework.PageObjects.SearchResults
{
    public class SearchResultsPage : BasePage
    {
        public SearchResultsPageMappings Mappings;
        public SearchResultsPage(IWebDriver driver) : base(driver)
        {
            Mappings = new SearchResultsPageMappings(driver);
        }

        public bool SearchResultsShouldContainsTextOnLocation(string text, IList<IWebElement> location)
        {
            bool isContains = false; 
            foreach (var element in location)
            {
                isContains = element.Text.ToLower().Contains(text.ToLower())==true?true:false;
                if (!isContains)
                {
                    break;
                }
            }
            return isContains;
        }

        public bool SearchResultOnParticularSiteShouldContainsPhraseOnTheHeaders(string text)
        {
            string phrase = text.Split(' ')[0];
            IList<IWebElement> location = Mappings.SearchResult_HeadersList;
            return SearchResultsShouldContainsTextOnLocation(phrase, location);
        }

        public bool SearchResultOnParticularSiteShouldContainssiteNameOnTheLinks(string text)
        {
            string link = text.Split(':').Last();
            IList<IWebElement> location = Mappings.SearchResult_LinksList;
            return SearchResultsShouldContainsTextOnLocation(link, location);
        }

        public bool SearchResulShouldContainsPhraseOnTheHeaders(string phrase)
        {
            IList<IWebElement> location = Mappings.SearchResult_HeadersList;
            return SearchResultsShouldContainsTextOnLocation(phrase, location);
        }

        public void SearchForAndLimitSearchResults(string phrase, int quantity)
        {
            UriBuilder baseUri = new UriBuilder("https://www.google.com/search");
            var parameters = HttpUtility.ParseQueryString(string.Empty);

            parameters["q"] = phrase;
            parameters["num"] = quantity.ToString();
            baseUri.Query = parameters.ToString();

            Uri finalUrl = baseUri.Uri;
            Helper.GoToUrl(finalUrl.ToString());
        }

        public int SearchResultsQuantityOnThePage(int page_number)
        {
            By page = By.XPath($"//a[text()={page_number}]");
            if (page_number > 1)
            { 
            Helper.GetElement(page).Click();
            }
            var links = Mappings.SearchResult_LinksList == null ? 0 : Mappings.SearchResult_LinksList.Count();
            var images = Mappings.SearchResult_ImagesList == null ? 0 : Mappings.SearchResult_ImagesList.Count();
            var videos = Mappings.SearchResult_VideosList == null ? 0 : Mappings.SearchResult_VideosList.Count();
            return links + images + videos;
        }
    }
}
