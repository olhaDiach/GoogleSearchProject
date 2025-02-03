using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium;

namespace GoogleSearchProject.Pages
{
    public abstract class BasePage
    {
        protected IWebDriver Driver;
        protected WebDriverWait Wait;

        public BasePage(IWebDriver driver)
        {
            Driver = driver;
            Wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
        }

        public void OpenUrl(string url)
        {
            Driver.Navigate().GoToUrl(url);
        }

        public bool IsElementDisplayed(By locator)
        {
            try
            {
                return Wait.Until(d => d.FindElement(locator).Displayed);
            }
            catch (NoSuchElementException)
            {
                return false;
            }
        }

        public IWebElement FindElement(By locator)
        {
            return Wait.Until(d => d.FindElement(locator));
        }

        public void Click(By locator)
        {
            FindElement(locator).Click();
        }

        public void EnterText(By locator, string text)
        {
            var element = FindElement(locator);
            element.Clear();
            element.SendKeys(text);
        }
    }
}