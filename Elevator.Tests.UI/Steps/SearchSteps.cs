using Tests.UI.Pages;
using System.Threading.Tasks;
using TechTalk.SpecFlow;

namespace PlaywrightDemo.Tests.UI.Features
{
    [Binding]
    public class SearchSteps
    {
        private readonly SearchHomePage _searchHomePage;

        public SearchSteps(SearchHomePage searchHomePage) => _searchHomePage = searchHomePage;

        [Given(@"the user is on the Search homepage")]
        public async Task VisitHomePage() => await _searchHomePage.GoToHomePage();

        [When(@"the user searches for '(.*)'")]
        public async Task UserSearchFor(string searchTerm) => await _searchHomePage.SearchAndEnter(searchTerm);

        [Then(@"the user gets the search results")]
        public async Task UserGetsTheRelatedContent() => await _searchHomePage.AssertSearchResults();
    }
}
