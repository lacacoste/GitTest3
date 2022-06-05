using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreFramework.Pages
{
    public class GlobalSQADragAndDropPage : GlobalSQABasePage
    {
        public GlobalSQADragAndDropPage(IWebDriver driver) : base (driver)
        {

        }

        public IWebElement photoManagerIFrame => driver.FindElement(By.CssSelector(".demo-frame.lazyloaded"));

        public IWebElement firstImageHeaderElement => driver.FindElement(By.XPath("//h5[text()='High Tatras']"));
        public IWebElement trashElement => driver.FindElement(By.XPath("//*[@id='trash']"));
        public IWebElement firstImageWhenInTrashElement => driver.FindElement(By.XPath("//*[@id='trash']//img[@alt='The peaks of High Tatras']"));

        public List<IWebElement> imagesInTheTrashElements => driver.FindElements(By.XPath("//*[@id='trash']//img")).ToList();
    }
}
