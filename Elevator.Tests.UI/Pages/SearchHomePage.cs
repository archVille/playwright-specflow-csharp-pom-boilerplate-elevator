using Microsoft.Playwright;
using PlaywrightDemo.Tests.UI.Hooks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Elevator.Tests.UI.Pages
{
    public class SearchHomePage
    {
        private readonly IPage _page;

        public SearchHomePage(IPage page)
        {
            _page = page;
        }

        private ILocator SearchInput => _page.Locator("input[id='searchbox_input']");
        private ILocator SearchButton => _page.Locator("button[type='submit']");
        private ILocator Results => _page.Locator(".react-results--main");

        
        public async Task GoToHomePage()
        {
           await _page.GotoAsync("https://duckduckgo.com/");
        }

        public async Task AssertPageContent()
        {
            //await Assertions.Expect(_user).ToHaveURLAsync("https://duckduckgo.com/");
            //await Assertions.Expect(SearchInput).ToBeVisibleAsync();
            //await Assertions.Expect(SearchButton).ToBeVisibleAsync();
        }

        public async Task SearchAndEnter(string searchTerm)
        {
            await SearchInput.TypeAsync(searchTerm);
            await SearchButton.ClickAsync();
        }

        public async Task AssertSearchResults()
        {
            await Assertions.Expect(Results).ToBeVisibleAsync();
        }
    }
}
