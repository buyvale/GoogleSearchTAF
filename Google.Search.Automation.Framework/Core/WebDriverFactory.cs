using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Reflection;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Firefox;
using System.IO;

namespace Google.Search.Automation.Framework.Core
{
   public class WebDriverFactory
    {
        internal IWebDriver CreateBrowser(Network type, Browsertype name)
        {
            switch (type)
            {
                case Network.Local:
                    switch (name)
                    {
                        case Browsertype.Chrome:
                            return GetChromeDriver();
                        case Browsertype.Edge:
                            return new EdgeDriver();
                        case Browsertype.Firefox:
                            return new FirefoxDriver();
                        default:
                            throw new ArgumentOutOfRangeException("No such browser");
                    }
                case Network.Remote:
                    //TODO
                    throw new NotImplementedException("Remote run is not implemented");
                default:
                    throw new ArgumentException("Unknown Environment");
            };

        }

        private IWebDriver GetChromeDriver()
        {
            var options = new ChromeOptions();
            options.AddArgument("--start-maximized");

            //used user profile to avoid triggering Google reCaptcha
            options.AddArgument("--user-data-dir=C:/Users/Alex/AppData/Local/Google/Chrome/User Data");
            options.AddArgument("--profile-directory=Profile 1");        
            return new ChromeDriver(options);
        }

        private IWebDriver CreateRemoteWebDriver()
        {
            //TODO
            throw new NotImplementedException();
        }
    }
}
