using Google.Search.Automation.Framework.Core;
using Google.Search.Automation.Framework.PageObjects;
using NUnit.Framework;
using System.Threading;

namespace Google.Search.UI.Tests.Tests
{
    [TestFixture]
    public class Search : TestBase
    {

        [Test]
        [Description("Title on the home page should be 'Google'")]
        [Author("Aleksey Buivalenko")]

        public void HomePageTitleValidation()
        {
            Assert.AreEqual("Google", Pages.Home.GetTtle(),"Title is not match");
        }

        [Test]
        [Description("Search for <vales> and check results")]
        [Author("Aleksey Buivalenko")]

        public void SearchForSomeValuesAndCheckResults([Values("cheese", "telephone", "tree")] string text)
        {
            Pages.Home.SearchForAndSubmitBySearchButton(text);
            Assert.IsTrue(Pages.SearchResults.
                SearchResulShouldContainsPhraseOnTheHeaders(text), "Searchig phrase is not contains in all results");
        }

        [Test]
        [Description("Search for 'cheese' and check links")]
        [Author("Aleksey Buivalenko")]

        public void SearchForSomeValuesAndCheckResultsLinks([Values("cheese site:wikipedia.com")] string text)
        {
            Pages.Home.SearchForAndSubmitByEnterKey(text);
            Assert.IsTrue(Pages.SearchResults.
                SearchResultOnParticularSiteShouldContainsPhraseOnTheHeaders(text), "Searchig phrase is not contains in all results");
            Assert.IsTrue(Pages.SearchResults.
                SearchResultOnParticularSiteShouldContainssiteNameOnTheLinks(text), "Link to the target site is not contains in all results ");
        }

        [Test]
        [Description("Search for 'cheese' and limit search reluts on the page")]
        [Author("Aleksey Buivalenko")]

        public void UserSearchForPhraseAndWhantToReceiveFirstNResults([Values(2,3,4,5,6,7)] int results_quantity)
        {
            Pages.SearchResults.SearchForAndLimitSearchResults("Cheese", results_quantity);
            Assert.AreEqual(results_quantity, Pages.SearchResults.SearchResultsQuantityOnThePage(4));
        }
    }
}
