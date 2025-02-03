using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoogleSearchProject.Pages
{
    public class SearchPage : BasePage
    {
        private readonly By SearchBox = By.Name("q");
        private readonly By FirstResult = By.CssSelector("h3");

        public SearchPage(IWebDriver driver) : base(driver) { }

        public void Open()
        {
            OpenUrl("https://www.google.com/");
        }

        public bool IsSearchBoxDisplayed() => IsElementDisplayed(SearchBox);

        public void Search(string query)
        {
            EnterText(SearchBox, query);
            FindElement(SearchBox).SendKeys(Keys.Enter);
        }

        public bool FirstResultContains(string keyword)
        {
            return FindElement(FirstResult).Text.Contains(keyword, StringComparison.OrdinalIgnoreCase);
        }
    }
}
