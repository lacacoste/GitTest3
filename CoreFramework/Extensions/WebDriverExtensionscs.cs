using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreFramework.Extensions
{
    public static class WebDriverExtensionscs
    {
        public static void SwitchToNewWindow(this IWebDriver driver ,ReadOnlyCollection<string> oldHandles, ReadOnlyCollection<string> newHandles)
        {
            driver.SwitchTo().Window(newHandles.Where(handle => !oldHandles.Contains(handle)).First());

        }

    }
}
