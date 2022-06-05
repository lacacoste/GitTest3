using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CoreFramework.Pages;
using CoreFramework.Extensions;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace UnitTestProject
{
    public class TestWithFramework
    {
        public IWebDriver driver;
        [SetUp]
        public void SetupMethod()
        {
            driver = new ChromeDriver();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            driver.Manage().Window.Maximize();
        }
        [Test]
        public void VerifyUkrNetSearch()
        {
            driver.Url = "https://www.ukr.net/";
            UkrNetHomePage homePage = new UkrNetHomePage(driver);

            var oldHandles = driver.WindowHandles;
            
            homePage.SearchInputField.SendKeys("Civilization 6");
            homePage.SearchInputField.Submit();
            driver.SwitchToNewWindow(oldHandles, driver.WindowHandles);
            oldHandles = driver.WindowHandles;

            var firstFoundLink = driver.FindElements(By.CssSelector("div>a.gs-title"));
            firstFoundLink[0].Click();
            driver.SwitchToNewWindow(oldHandles, driver.WindowHandles);
            oldHandles = driver.WindowHandles;

            string expectedResult = "Sid Meier’s Civilization® VI on Steam";
            string actualResult = driver.Title.Trim();

            Assert.AreEqual(expectedResult, actualResult, $"System Expetected result is: {expectedResult}, but Actual result is:{actualResult}");
        }



        [TearDown]
        public void AfterEachTest()
        {
            driver.Quit();
        }
    }
}
