using CoreFramework.Pages;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace UnitTestProject
{
    public class SQATests
    {
        public IWebDriver driver;
        [SetUp]
        public void BeforeEachTest()
        {
            driver = new ChromeDriver();

            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(20);
            driver.Manage().Window.Maximize();
        }

        [TearDown]
        public void AfterEachTest()
        {
            driver.Quit();
        }

        [Test]
        public void DragAndDropImageToTrash()
        {
            //Arrange
            driver.Url = "https://www.globalsqa.com/demo-site/draganddrop/";
            GlobalSQADragAndDropPage page = new GlobalSQADragAndDropPage(this.driver);

            //Act
            driver.SwitchTo().Frame(page.photoManagerIFrame);
            
            Actions action = new Actions(driver);
            action.DragAndDrop(page.firstImageHeaderElement,page.trashElement).Perform();

            //Assert
            var actualCount = page.imagesInTheTrashElements.Count();
            var expectedCount = 1;

            string imageAltExpected = "The peaks of High Tatras";
            IWebElement imgInTrash = driver.FindElement(By.CssSelector("#trash img"));
            string imgAltActual = imgInTrash.GetAttribute("alt");



            Assert.Multiple(() =>
            {
                Assert.AreEqual(expectedCount, actualCount, $"The Expected result is {expectedCount}, but the actual result is {actualCount}");
                Assert.AreEqual(imageAltExpected,imgAltActual, $"The Expected image alt is: {imageAltExpected},but actual is: {imgAltActual}");
            }

            );

                      
        }

    }
}
