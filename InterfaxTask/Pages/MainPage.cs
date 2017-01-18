using System;
using Bumblebee.Implementation;
using Bumblebee.Interfaces;
using Bumblebee.Setup;
using InterfaxTask.Controls;
using OpenQA.Selenium;

namespace InterfaxTask.Pages
{
    internal class MainPage : WebBlock
    {
        public Session _session;

        public MainPage(Session session) : base(session)
        {
            _session = session;
            if (!FindElement(By.XPath("//div[contains(@class, 'bLogo')]/*[@class='logo']/a[@title='Новости Интерфакс']")).Enabled)
            {
                throw new Exception("Current page isn't the Interfax main page");
            }
            //Tag = FindElement(By.TagName("body"));
        }


        public IClickable<MainPage> SearchButton
        {
            get
            {
                return new Clickable<MainPage>(this, By.XPath("//input[@type='submit']"));
            }
        }

        public ITextField SearchField
        {
            get
            {
                return new TextField(this, Tag.FindElement(By.XPath("//div[@class='search']/form[@name='search']/input[@name='sw']")));
            }
        }

        public SearchForm SearchForm
        {
            get { return new SearchForm(_session); }
        }
    }
}