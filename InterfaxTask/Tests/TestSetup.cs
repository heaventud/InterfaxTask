using System.Configuration;
using Bumblebee.Setup;
using NUnit.Framework;
using OpenQA.Selenium;
using InterfaxTask.Common;

namespace InterfaxTask.Tests
{
    [SetUpFixture]    
    public class TestSetup
    {
            public static Session Session;

            [OneTimeSetUp]
            public void Init()
            {
                var browser = ConfigurationManager.AppSettings["BrowserType"];
                IDriverEnvironment driver;

                switch (browser)
                {
                    case "firefox":
                        driver = new LocalFirefoxEnvironment();
                        break;
                    case "iexplore":
                        driver = new LocalInternetExplorerEnvironment();
                        break;
                    case "chrome":
                        driver = new LocalChromeEnvironment();
                        break;
                    default:
                        throw new WebDriverException("There are no browsers");
                }

                Session = new Session(driver);
            }

            [OneTimeTearDown]
            public void Cleanup()
            {
                Session.End();
            }
        }
}