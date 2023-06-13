using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;
using BoDi;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SpecFlowWithSelenium.Drivers;
using SpecFlowWithSelenium.PageObjects;
using System.Reflection;
using TechTalk.SpecFlow;

namespace SpecFlowWithSelenium.Support
{
    [Binding]
    public  class Hooks
    {
        private readonly IObjectContainer objectContainer;
        private IWebDriver _driver;
        //private WebDriverWait _wait;
        private readonly string _browser = "Chrome";
        public DriverBase driverBase;
        public LoginUser _loginUser;
       

        private readonly string _userName = "standard_user";
        private readonly string _password = "secret_sauce";

        public Hooks(IObjectContainer objectContainer)
        {
            this.objectContainer = objectContainer;
        }


        // For additional details on SpecFlow hooks see http://go.specflow.org/doc-hooks

        [BeforeScenario("@Test")]
        public void BeforeScenarioWithTag()
        {
            driverBase = new DriverBase();
            _driver = driverBase.Initiate(_browser);
           // _wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(10));
            _driver.Manage().Window.Maximize();
            _driver.Navigate().GoToUrl("https://www.saucedemo.com/");
            objectContainer.RegisterInstanceAs<IWebDriver>(_driver);
            
            _loginUser = new LoginUser(_driver);
            _loginUser.Login(_userName, _password);
            GenerateReport();
        }

        [BeforeScenario("@LoginTag")]
        public void BeforeScenario()
        {
            driverBase = new DriverBase();
            _driver = driverBase.Initiate(_browser);
            //_wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(10));
            _driver.Manage().Window.Maximize();
            objectContainer.RegisterInstanceAs<IWebDriver>(_driver);
            
            GenerateReport();
        }

        [AfterScenario]
        public void AfterScenario()
        {
           IWebDriver driver = objectContainer.Resolve<IWebDriver>();
            GenerateReport();
            driver.Quit();
            
        }


        public void GenerateReport()
        {
            var extent = new ExtentReports();
            var htmlReporter = new ExtentHtmlReporter(@"D:\Workspace\SpecFlowWithSelenium\Report" +DateTime.Now.ToString("MM-dd-yyyy")+".html");
            extent.AttachReporter(htmlReporter);
            extent.Flush();
           

           
        }
    }
}