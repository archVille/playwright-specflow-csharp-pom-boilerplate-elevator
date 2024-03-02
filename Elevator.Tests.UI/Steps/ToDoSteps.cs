using FluentAssertions;
using NUnit.Framework;
using PlaywrightDemo.Pages;
using System.Linq;
using System.Threading.Tasks;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;
using Microsoft.Playwright;

namespace PlaywrightDemo.Tests.UI.Features
{
    [Binding]
    public class ToDoSteps
    {
        private readonly ToDoPage _todoPage;

        public ToDoSteps(IPage page, ToDoPage todoPage) 
        { 
            _todoPage = todoPage;
        }

        [Given(@"user has navigated to the app")]
        public void VisitPageAsync()
        {
            // step is empty as syntactic sugar
            // essentially, all tests require visiting the page
            // therefore that is done in a common setup binding
        }

        [Given(@"user adds a new card '(.*)'")]
        [When(@"user adds a new card '(.*)'")]
        public async Task AddNewCardAsync(string cardName)
        {
            await _todoPage.AddNewCard(cardName);
        }

        [When(@"user removes card '(.*)'")]
        public async Task RemoveCardAsync(string cardName)
        {
            await _todoPage.RemoveCard(cardName);
        }

        [Then(@"the card should appear as active")]
        public async Task AssertCardIsActiveAsync()
        {
            var allCards = await _todoPage.AllToDos;
            Assert.AreEqual(1, allCards.Count());
        }

        [Then(@"the card '(.*)' should no longer appear as active")]
        public async Task AssertCardIsRemovedAsync(string cardName)
        {
            var card = await _todoPage.SelectCard(cardName);
            Assert.AreEqual(null, card);

        }

        [Given(@"user has navigated to the app for the first time")]
        public void VisitAppFirstTimeAsync()
        {
            // theoretically, this step could imitate first time navigation by making sure, e.g. local storage is cleaned
        }

        [Then(@"there should be no cards")]
        public async Task AssertNoCardsArePresentAsync()
        {
            var allCards = await _todoPage.AllToDos;
            Assert.AreEqual(0, allCards.Count());
        }

        [When(@"user adds a new card with the task ""([^""]*)""")]
        public async Task AddNewCardNamedAsync(string todo)
        {
            await _todoPage.AddNewCard(todo);
        }

        [Then(@"the new card is present")]
        public async Task AssertCardIsPresent()
        {
            var allCards = await _todoPage.AllToDos;
            Assert.AreEqual(1, allCards.Count());
        }

        [Then(@"the card appears as active")]
        public async Task SwitchActiveAndAssertCardIsPresentAsync()
        {
            await _todoPage.SwitchToActive();
            var allCards = await _todoPage.AllToDos;
            Assert.AreEqual(1, allCards.Count());
        }       
    }
}
