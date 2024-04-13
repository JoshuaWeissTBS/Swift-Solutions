using PopNGo.Utilities;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using PopNGo_BDD_Tests.Shared;
using System.Collections.ObjectModel;
using PopNGo_BDD_Tests.PageObjects;
using PopNGo_BDD_Tests.Drivers;
using OpenQA.Selenium.Chrome; // Add this line
using OpenQA.Selenium.Edge; // Add this line
using OpenQA.Selenium.Firefox; // Add this line

namespace PopNGo_BDD_Tests.StepDefinitions
{
    [Binding]
    public sealed class BookmarkListsStepDefinitions
    {
        private readonly FavoritesPageObject _favoritesPage;
        private readonly IWebDriver _webDriver;

        public BookmarkListsStepDefinitions(Drivers.BrowserDriver browserDriver)
        {
            _webDriver = browserDriver.Current; // Or use another browser driver
            _favoritesPage = new FavoritesPageObject(_webDriver);
        }

        [Then("I should see a bookmark list")]
        public void ThenIShouldSeeABookmarkList()
        {
            // Check that there is at least one bookmark list
            _favoritesPage.BookmarkLists.Count.Should().BeGreaterThan(0);
        }

        [Then("I should see a way to create a new bookmark list")]
        public void ThenIShouldSeeAWayToCreateANewBookmarkList()
        {
            _favoritesPage.NewBookmarkListNameInput.Displayed.Should().BeTrue();
            _favoritesPage.CreateBookmarkListButton.Displayed.Should().BeTrue();
        }
    }
}
