
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.ObjectModel;
using System.Linq;

namespace UnitTestProject
{
    public class Tests
    {
        public IWebDriver driver;

        [OneTimeSetUp]
        public void OneTimeSetupMethod()
        {

        }

        [SetUp]
        public void SetupMethod()
        {
            driver = new ChromeDriver();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            driver.Manage().Window.Maximize();
        }

        [TearDown]
        public void AfterEachTest()
        {
            driver.Quit();
        }

        [Category("Smoke")]
        [Test]
        public void Testic()
        {
            Console.WriteLine("First Unit test");
           // throw new NotImplementedException();
        }

        [Category("Regression")]
        [Test]
        public void AddTwoNumber_Positive()
        {
            // arrange
            int firstNumber = 3;
            int secondNumber = 5;

            int expetcedResult = 8;

            //act
            var actualResult = Calculator.AddTwoNumbers(firstNumber,secondNumber);

            //assert

            Assert.True(actualResult == expetcedResult, "Expected result is " + expetcedResult + ", but Actual result is " + actualResult);

        }

        [Test]
        public void CheckIWebDriverAndIWebElements()
        {
            
            
            //arrange
            driver.Url = "https://kasamba.com";

            //act
            var linkToSignUp = driver.FindElement(By.CssSelector("#ctl00_Header_LiteHeader1_lnkHeaderRegister"));
            linkToSignUp.Click();

            var linkToLoginFromRegister = driver.FindElement(By.CssSelector("#siginlink"));
            linkToLoginFromRegister.Click();

            string expectedResult = "Kasamba - Member Sign in";
            string actualResult = driver.Title.Trim();

            #region Methods
            /*
            linkToLoginFromRegister.Clear(); // clear the input
            linkToLoginFromRegister.SendKeys("text"); // send text to input
            linkToLoginFromRegister.FindElement(By.CssSelector(".//test")); // find child in element

            var elementText = linkToLoginFromRegister.Text; // return innerText
            bool enbaled = linkToLoginFromRegister.Enabled; // is element enabled
            bool displayed = linkToLoginFromRegister.Displayed; // is element displayed

            
            elementText = linkToLoginFromRegister.GetAttribute("innerText");
            elementText = linkToLoginFromRegister.GetAttribute("alt");
            elementText = linkToLoginFromRegister.GetAttribute("textContent"); // preferable method to get text

            //just for input
            elementText = linkToLoginFromRegister.GetAttribute("value");

            // for checkbox and radio-buttons
            bool isSelected = linkToLoginFromRegister.Selected;
            */
            #endregion 
            //assert
            Assert.AreEqual(expectedResult, actualResult, $"System Expetected result is: {expectedResult}, but Actual result is:{actualResult}");
            
        }

        [Test]
        public void UkrNetSearch()
        {
            driver.Url = "https://www.ukr.net/";
            var homePageHandle = driver.CurrentWindowHandle;

            var searchInput = driver.FindElement(By.Id("search-input"));

            searchInput.SendKeys("Civilization 6");
            searchInput.Submit();

            var allHandles = driver.WindowHandles;
            foreach (var handle in allHandles)
            {
                if (handle != homePageHandle)
                    driver.SwitchTo().Window(handle);
            }
                        
            var firstFoundLink = driver.FindElements(By.CssSelector("div>a.gs-title"));
            var searchResultsPageHandle = driver.CurrentWindowHandle;
            
            firstFoundLink[0].Click();

            allHandles = driver.WindowHandles;
            foreach (var handle in allHandles)
            {
                if (handle != homePageHandle && handle != searchResultsPageHandle)
                    driver.SwitchTo().Window(handle);
            }

            


            string expectedResult = "Sid Meier’s Civilization® VI on Steam";
            string actualResult = driver.Title.Trim();

            Assert.AreEqual(expectedResult, actualResult, $"System Expetected result is: {expectedResult}, but Actual result is:{actualResult}");

        }

        /// <summary>
        /// Change the active tab to the new opened tab
        /// </summary>
        /// <param name="oldHandles">ReadOnlyCollection<string></param>
        /// <param name="newHandles">ReadOnlyCollection<string></param>
        private void SwitchToNewWindow(ReadOnlyCollection<string> oldHandles, ReadOnlyCollection<string> newHandles)
        {
            /*
            foreach (var handle in newHandles)
                if (!oldHandles.Contains(handle))
                    this.driver.SwitchTo().Window(handle);
            */

            driver.SwitchTo().Window(newHandles.Where(handle => !oldHandles.Contains(handle)).First());

        }

        [Test]
        public void UkrNetSearchWithWindowHandle()
        {
            driver.Url = "https://www.ukr.net/";

            var oldHandles = driver.WindowHandles;
            var searchInput = driver.FindElement(By.Id("search-input"));

            searchInput.SendKeys("Civilization 6");
            searchInput.Submit();
            SwitchToNewWindow(oldHandles, driver.WindowHandles);
            oldHandles = driver.WindowHandles;

            var firstFoundLink = driver.FindElements(By.CssSelector("div>a.gs-title"));
            firstFoundLink[0].Click();
            SwitchToNewWindow(oldHandles, driver.WindowHandles);
            oldHandles = driver.WindowHandles;

            string expectedResult = "Sid Meier’s Civilization® VI on Steam";
            string actualResult = driver.Title.Trim();

            Assert.AreEqual(expectedResult, actualResult, $"System Expetected result is: {expectedResult}, but Actual result is:{actualResult}");
       
        }
    }
}
