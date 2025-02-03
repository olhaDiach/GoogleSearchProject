using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;

namespace GoogleSearchProject.Tests
{
    public class BaseTest
    {
        protected IWebDriver Driver;
        protected WebDriverWait Wait;

        [SetUp]
        public void Setup()
        {
            var options = new ChromeOptions();
            Driver = new ChromeDriver(options);
            Wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(10));
        }

        [TearDown]
        public void TearDown()
        {
            Driver?.Quit();
            Driver?.Dispose();
        }
    }
}


