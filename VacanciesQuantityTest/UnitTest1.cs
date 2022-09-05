using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Threading;

namespace VacanciesQuantityTest
{
    public class Tests
    {
        private IWebDriver driver;

        private readonly By _languageButton = By.XPath("//button[text()='All languages']");
        private readonly By _englishCheckBox = By.XPath("//input[@id='lang-option-0']");
        /*
         * English - 0
         * Russian - 1
         * French - 2
         * German - 3
         * Spanish - 4
         */
        
        private readonly By _cookiesButton = By.XPath("//div[@id='cookiescript_accept']");
        private readonly By _vacanciesQuantity = By.XPath("//span[@class='text-secondary pl-2']");

        private const int _expectedQuantity = 62;

        [SetUp]
        public void Setup()
        {
            driver = new OpenQA.Selenium.Chrome.ChromeDriver();
            driver.Navigate().GoToUrl("https://cz.careers.veeam.com/vacancies");
            driver.Manage().Window.Maximize();

        }

        [Test]
        public void Test1()
        {
            Thread.Sleep(400);
            var cookie = driver.FindElement(_cookiesButton);
            cookie.Click();
            var lang = driver.FindElement(_languageButton);
            lang.Click();
            
            
            var eng = driver.FindElement(_englishCheckBox);
            
            eng.Click();

            var actual = Int32.Parse(driver.FindElement(_vacanciesQuantity).Text);
            
            
            Assert.AreEqual(_expectedQuantity, actual, "Not expected quantity of vacancies");
        }

        [TearDown]

        public void TearDown()
        {
            driver.Quit();

        }
    }
}