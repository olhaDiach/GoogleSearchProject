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
            var chromeOptions = new ChromeOptions();
            chromeOptions.AddArguments("--headless");  
            chromeOptions.AddArguments("--disable-gpu");  
            chromeOptions.AddArguments("--no-sandbox");  
            chromeOptions.AddArguments("--disable-dev-shm-usage"); 
            chromeOptions.AddArguments("--remote-debugging-port=9222");  
            chromeOptions.AddArguments("--window-size=1920,1080");  
            chromeOptions.AddArguments("--disable-features=VizDisplayCompositor");
            // Fix for "user data directory already in use" issue
            chromeOptions.AddArguments($"--user-data-dir=/tmp/chrome-profile-{Guid.NewGuid()}");
            Driver = new ChromeDriver(chromeOptions);
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


