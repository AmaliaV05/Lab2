using System;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;

namespace Tests
{
    class Test_Project2App
    {
        private IWebDriver _driver;
        [SetUp]
        public void SetupDriver()
        {
            _driver = new ChromeDriver("C:/Users/Asus/Downloads/");
        }

        [TearDown]
        public void CloseBrowser()
        {
            _driver.Close();
        }

        [Test]
        public void LoginIsSuccessful()
        {
            _driver.Url = "http://localhost:8100/login";

            var email = _driver.FindElement(By.XPath("//*[@id='content1']/app-login/ion-content/div/form/ion-item[1]/ion-input/input"));
            email.SendKeys("test2@test.com");

            var password = _driver.FindElement(By.XPath("//*[@id='content1']/app-login/ion-content/div/form/ion-item[2]/ion-input/input"));
            password.SendKeys("Gintama10!"); 
            
            System.Threading.Thread.Sleep(2000);

            var loginButton = _driver.FindElement(By.XPath("//*[@id='content1']/app-login/ion-content/div/form/ion-button"));
            loginButton.Click(); 
            
            System.Threading.Thread.Sleep(2000);

            string actualUrl = "http://localhost:8100/films";
            string expectedUrl = _driver.Url;
            Assert.AreEqual(expectedUrl, actualUrl);
        }

        [Test]
        public void DeletingAFilmWorks()
        {
            _driver.Url = "http://localhost:8100/login";

            var email = _driver.FindElement(By.XPath("//*[@id='content1']/app-login/ion-content/div/form/ion-item[1]/ion-input/input"));
            email.SendKeys("test2@test.com");

            var password = _driver.FindElement(By.XPath("//*[@id='content1']/app-login/ion-content/div/form/ion-item[2]/ion-input/input"));
            password.SendKeys("Gintama10!");

            System.Threading.Thread.Sleep(2000);

            var loginButton = _driver.FindElement(By.XPath("//*[@id='content1']/app-login/ion-content/div/form/ion-button"));
            loginButton.Click();

            System.Threading.Thread.Sleep(10000);

            var deleteIcon = _driver.FindElement(By.XPath("//*[@id='content1']/app-films/ion-content/ion-list/ion-item[5]/ion-icon[1]"));
            deleteIcon.Click();

            System.Threading.Thread.Sleep(2000);

            var numberOfFilms =_driver.FindElements(By.XPath("//*[@id='content1']/app-films/ion-content/ion-list/ion-item")).Count;
            Assert.AreEqual(4, numberOfFilms);
        }

        [Test]
        public void AddAFilmButtonIsWorking()
        {
            _driver.Url = "http://localhost:8100/films";

            var addButton = _driver.FindElement(By.XPath("//*[@id='content1']/app-films/ion-footer/ion-button"));
            addButton.Click();

            System.Threading.Thread.Sleep(2000);

            string actualUrl = "http://localhost:8100/films/add";
            string expectedUrl = _driver.Url;
            Assert.AreEqual(expectedUrl, actualUrl);
        }

        [Test]
        public void EditAFilmIconIsOpeningAnEditingPage()
        {
            _driver.Url = "http://localhost:8100/login";

            var email = _driver.FindElement(By.XPath("//*[@id='content1']/app-login/ion-content/div/form/ion-item[1]/ion-input/input"));
            email.SendKeys("test2@test.com");

            var password = _driver.FindElement(By.XPath("//*[@id='content1']/app-login/ion-content/div/form/ion-item[2]/ion-input/input"));
            password.SendKeys("Gintama10!");

            System.Threading.Thread.Sleep(10000);

            var editIcon = _driver.FindElement(By.XPath("//*[@id='content1']/app-films/ion-content/ion-list/ion-item[4]/ion-icon[2]"));
            editIcon.Click();

            string actualUrl = "http://localhost:8100/film/28";
            string expectedUrl = _driver.Url;
            Assert.AreEqual(expectedUrl, actualUrl);
        }

    }
}
