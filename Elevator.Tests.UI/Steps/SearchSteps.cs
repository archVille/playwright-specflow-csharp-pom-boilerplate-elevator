using FluentAssertions;
using NUnit.Framework;
using PlaywrightDemo.Pages;
using System.Linq;
using System.Threading.Tasks;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;
using Microsoft.Playwright;
using Elevator.Tests.UI.Pages;

namespace PlaywrightDemo.Tests.UI.Features
{
    [Binding]
    public class SearchSteps
    {
        private readonly SearchHomePage _searchHomePage;

        public SearchSteps(SearchHomePage searchHomePage)
        {
            _searchHomePage = searchHomePage;
        }

        [Given(@"user has navigated to the search page")]
        public async Task VisitPageAsync() => await _searchHomePage.GoToHomePage();

        [Given(@"the user is on the DuckDuckGo homepage")]
        public async Task GivenTheUserIsOnTheDuckDuckGoHomepage()
        {
            await _searchHomePage.AssertPageContent();
        }

        [When(@"the user searches for '(.*)'")]
        public async Task WhenTheUserSearchesFor(string searchTerm)
        {
            //Type the search term and press enter
            await _searchHomePage.SearchAndEnter(searchTerm);
        }
    }
}
