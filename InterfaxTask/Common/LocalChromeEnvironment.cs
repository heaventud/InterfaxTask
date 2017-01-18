using System;
using System.Configuration;
using Bumblebee.Setup;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace InterfaxTask.Common
{
    public class LocalChromeEnvironment : IDriverEnvironment
    {
        public IWebDriver CreateWebDriver()
        {
            ChromeOptions chromeOptions = new ChromeOptions(); ;
            IWebDriver driver = new ChromeDriver(ConfigurationManager.AppSettings["ChromeDriverPath"], chromeOptions);
            return driver;
        }
    }
}