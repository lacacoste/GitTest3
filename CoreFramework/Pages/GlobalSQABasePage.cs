using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreFramework.Pages
{
    public class GlobalSQABasePage
    {
        protected IWebDriver driver;

        public GlobalSQABasePage(IWebDriver driver)
        {
            this.driver = driver;
        }

    }
}
