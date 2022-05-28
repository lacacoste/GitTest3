
using NUnit.Framework;
using System;

namespace UnitTestProject
{
    public class Tests
    {
        [OneTimeSetUp]
        public void OneTimeSetupMethod()
        {

        }

        [SetUp]
        public void SetupMethod()
        {

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

        }
    }
}
