using OpenQA.Selenium;
using Google.Search.Automation.Framework.Utils;


namespace Google.Search.Automation.Framework.PageObjects
{
    public class BasePage
    {
    public IWebDriver Driver { get; private set; }
    public Helpers Helper { get; set; }

    public BasePage(IWebDriver driver)
    {
        Helper = new Helpers(driver);
        Driver = driver;
    }
}
}
