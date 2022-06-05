using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreFramework.Pages
{
    public class UkrNetHomePage
    {
        private IWebDriver driver;
        public UkrNetHomePage(IWebDriver driver)
        {
            this.driver = driver;

        }

        public IWebElement SearchInputField => driver.FindElement(By.Id("search-input"));


    }
}
