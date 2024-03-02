using Microsoft.Playwright;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace PlaywrightDemo.Pages
{
    public class ToDoPage
    {
        private readonly IPage _page;

        public ToDoPage(IPage page)
        {
            _page = page;
        }

        public Task<IReadOnlyList<IElementHandle>> AllToDos => _page.QuerySelectorAllAsync(".todo-list .view");

        public async Task MarkToDoAsDone(string cardName)
        {
            var allCheckBoxes = await AllToDos;
            var todoCard = allCheckBoxes.FirstOrDefault(x => x.TextContentAsync().Result == cardName);
            var checkbox = await todoCard.QuerySelectorAsync("input[type='checkbox']");
            await checkbox.CheckAsync();
        }

        public async Task AddNewCard(string cardName)
        {
            var input = await _page.QuerySelectorAsync(".new-todo");
            await input.ClickAsync();
            await input.FillAsync(cardName);
            await input.PressAsync("Enter");
        }

        public async Task RemoveCard(string cardName)
        {
            var destroyElement = await _page.QuerySelectorAsync($".destroy");
            if (destroyElement != null)
            {
                await destroyElement.ClickAsync();
            }
        }

        public async Task SwitchToCompleted()
        {
            await _page.ClickAsync("a[href*='completed']");
        }

        public async Task SwitchToActive()
        {
            await _page.ClickAsync("a[href*='active']");
        }

        public async Task<IElementHandle> SelectCard(string cardName)
        {
            var cardElement = await _page.QuerySelectorAsync($"//*[text() = '{cardName}']");
            return cardElement;
        }
    }
}
