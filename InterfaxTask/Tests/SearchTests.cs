using System;
using System.Configuration;
using System.Text.RegularExpressions;
using System.Linq;
using Bumblebee.Setup;
using InterfaxTask.Controls;
using InterfaxTask.Pages;
using NUnit.Framework;

namespace InterfaxTask.Tests
{
    [TestFixture]
    public class SearchTests
    {
        private MainPage page;
        private Session Session = TestSetup.Session;
        
        [OneTimeSetUp]
        public void TestSetUp()
        {
            Session.Driver.Manage().Window.Maximize();
            Session.Driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(3));
            page = Session.NavigateTo<MainPage>(ConfigurationManager.AppSettings["BaseUrl"]);
        }

        [Test]
        public void TC001_SearchTest()
        {
            page.SearchButton.Click<MainPage>()
                .SearchField.EnterText<MainPage>("Викинг").SearchButton.Click<MainPage>();
            var result = page.SearchForm.GetSearchStats();
            var match = Regex.Match(result, @"Найдено (\d+) совпадений");
            var numMatches = Convert.ToInt32(match.Groups[1].Value);
            Assert.Greater(numMatches, 0);
        }

        [Test]
        public void TC002_SearchTest()
        {
            Session.CurrentBlock<MainPage>().SearchForm.SearchArea.Click();
            Session.CurrentBlock<MainPage>().SearchForm.SearchArea.Options
                .Single(opt => opt.Text.Equals("В России")).Click();
            Session.CurrentBlock<MainPage>().SearchForm.SearchInSectionsButton.Click<MainPage>();
            var result = page.SearchForm.GetSearchStats();
            var match = Regex.Match(result, @"Найдено (\d+) совпадений");
            var numMatches = Convert.ToInt32(match.Groups[1].Value);
            Assert.Greater(numMatches, 0);
        }
    }
}
