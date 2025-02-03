using OpenQA.Selenium;

namespace GoogleSearchProject.Tests
{
    public class SearchSeleniumTutorialTest : BaseTest
    {
        [Test]
        //Test
        public void GoogleSearch_Should_ShowResults()
        {
            Driver.Navigate().GoToUrl("https://www.google.com");
            var searchBox = Wait.Until(d => d.FindElement(By.Name("q")));
            Assert.That(searchBox.Displayed, "Search field is anavaliable");
            searchBox.SendKeys("Selenium C# tutorial");
            searchBox.SendKeys(Keys.Enter);
            var searchResults = Wait.Until(d => d.FindElements(By.CssSelector("h3")));
            Assert.That(searchResults, Is.Not.Empty);
            string firstResultText = searchResults.First().Text;
            Assert.That(firstResultText, Does.Contain("Selenium"), $"First result doesn't contain 'Selenium'. Text: {firstResultText}");
        }
    }
}