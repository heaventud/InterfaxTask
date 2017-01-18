using System;
using System.Configuration;
using Bumblebee.Setup;
using OpenQA.Selenium;
using OpenQA.Selenium.IE;

namespace InterfaxTask.Common
{
    public class LocalInternetExplorerEnvironment : IDriverEnvironment
    {
        private InternetExplorerOptions iexplorerOptions;

        private static InternetExplorerOptions InitInternetExplorerOptions()
        {
            var options = new InternetExplorerOptions
            {
                IntroduceInstabilityByIgnoringProtectedModeSettings = true,
                EnsureCleanSession = true
            };

            return options;
        }
        
        public IWebDriver CreateWebDriver()
        {
            iexplorerOptions = InitInternetExplorerOptions();
            var driver = new InternetExplorerDriver(ConfigurationManager.AppSettings["IExplorerDriverPath"], iexplorerOptions);
            return driver;
        }
    }
}

