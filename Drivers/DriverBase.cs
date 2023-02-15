﻿using OpenQA.Selenium;
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
            switch (browser.ToLowerInvariant())
            {
                case "chrome":
                    var chromeOptions = new ChromeOptions();
                    chromeOptions.AddArguments("--headless");
                    chromeOptions.AddArguments("--allowed-ips='31,11,88,86'");
                    driver = new ChromeDriver(chromeOptions);
                    break;
                case "firefox":
                    driver = new FirefoxDriver();
                    break;
                default:
                    throw new ArgumentException($"Browser is not valid{browser}");
            }

            return driver;
        }
    }
}
