using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpecFlowWithSelenium.Drivers
{
    public class DriverBase
    {
        private IWebDriver driver;

        public IWebDriver Initiate(string browser)
        {
            return browser switch
            {
                "chrome" => GetChromeDriver(),
                "firefox" => GetFirefoxDriver(),
                _ => throw new ArgumentException($"Browser is not valid {browser}")
            };
        }

        private IWebDriver GetChromeDriver()
        {
           
            driver = new ChromeDriver(GetChromeOptions());
            return driver;
        }

        private ChromeOptions GetChromeOptions()
        {
            var chromeOptions = new ChromeOptions();
            chromeOptions.AddArguments("--headless=new");
            return chromeOptions;
        }


        private IWebDriver GetFirefoxDriver()
        {
            driver = new FirefoxDriver();
            return driver;
        }
    }
}
