using System.Collections.Generic;
using Bumblebee.Implementation;
using Bumblebee.Interfaces;
using Bumblebee.Setup;
using OpenQA.Selenium;

namespace InterfaxTask.Controls
{
    internal class SearchForm : WebBlock
    {
        private Session _session;
        
        public SearchForm(Session session) : base(session)
        {
            _session = session;
            Tag = FindElement(By.XPath("//form[@class='sPageForm']"));
        }

        public ITextField SearchField
        {
            get
            {
                return new TextField(this, Tag.FindElement(By.XPath(".//input[@name='sw']")));
            }
        }

        public IClickable SearchButton
        {
            get
            {
                return new Clickable(this, Tag.FindElement(By.XPath(".//div[@class='search']/span")));
            }
        }

        public IClickable SearchInSectionsButton
        {
            get
            {
                return new Clickable(this, Tag.FindElement(By.XPath(".//input[@value='уточнить поиск']")));
            }
        }

        public string GetSearchStats()
        {
            return FindElement(By.XPath("//div[@class='sPageResult__total']")).Text; 
        }

        public SearchArea SearchArea
        {
            get
            {
                return new SearchArea(_session, Tag);
            }
        }
    }

    internal class SearchArea : WebBlock
    {
        public SearchArea(Session session, IWebElement parent) : base(session)
        {
            Tag = parent.FindElement(By.XPath(".//div[@class='select']"));
        }

        public SearchArea Click()
        {
            Tag.FindElement(By.XPath("//div[@class='sec_list']/span")).Click();
            return this;
        }

        public IEnumerable<IWebElement> Options
        {
            get
            {
                return Tag.FindElements(By.XPath(".//ul[@class='sec_all']/li"));
            }
        }
    }
}
