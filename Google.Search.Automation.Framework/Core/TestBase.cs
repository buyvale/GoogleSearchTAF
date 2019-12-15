using Google.Search.Automation.Framework.PageObjects;
using NUnit.Framework;
using OpenQA.Selenium;

namespace Google.Search.Automation.Framework.Core
{
    public class TestBase
    {
        public IWebDriver driver { get; private set; }

        [SetUp]
        public void TestSetup()
        {
            var factory = new WebDriverFactory();
            driver = factory.CreateBrowser(Network.Local, Browsertype.Chrome);
            Pages.Init(driver);
            Pages.Home.GoTo("https://www.google.com/");
        }

        [TearDown]
        public void TestEnding()
        {
            driver.Close();
            driver.Quit();
        }
    }
}
