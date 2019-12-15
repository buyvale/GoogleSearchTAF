using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Google.Search.Automation.Framework.PageObjects.Home.Mappings
{
   public class HomePageMappings : BasePage
    {
        public HomePageMappings(IWebDriver driver) : base(driver)
        {
        }

        public IWebElement Search_Field => Helper.GetElement(By.CssSelector("input[name = 'q']"));
        public IWebElement Search_Button => Helper.GetElement(By.CssSelector("input[name = 'btnK']"));
    }  
}
