using System;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace Tests
{
    public class Test_eMag
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
        public void EmagGeniusTextExists()
        {
            _driver.Url = "https://www.emag.ro";
            bool foundGenius = false;
            foreach (var span in _driver.FindElements(By.TagName("span")))
            {
                if (span.Text == "eMAG Genius")
                {
                    foundGenius = true;
                    break;
                }
            }
            Assert.IsTrue(foundGenius);
        }

        [Test]
        public void EmagGeniusPageHasLogo()
        {
            _driver.Url = "https://www.emag.ro";
            bool foundGenius = false;
            foreach (var span in _driver.FindElements(By.TagName("span")))
            {
                if (span.Text == "eMAG Genius")
                {
                    foundGenius = true;
                    span.Click();
                    try
                    {
                        _driver.FindElement(By.XPath("//img[@class='g-logo']"));
                        //Assert.True(true);
                    }
                    catch (NoSuchElementException)
                    {
                        Assert.Fail("eMAG Genius logo not found.");
                    }
                    break;
                }
            }
            Assert.IsTrue(foundGenius);
        }
    }
}
