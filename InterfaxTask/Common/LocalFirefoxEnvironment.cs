using Bumblebee.Setup;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;

namespace InterfaxTask.Common
{
    public class LocalFirefoxEnvironment : IDriverEnvironment
    {
        public IWebDriver CreateWebDriver()
        {
            IWebDriver driver = new FirefoxDriver();
            return driver;
        }
    }
}