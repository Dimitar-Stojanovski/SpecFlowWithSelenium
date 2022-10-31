using BoDi;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SpecFlowWithSelenium.Drivers;
using TechTalk.SpecFlow;

namespace SpecFlowWithSelenium.Support
{
    [Binding]
    public  class Hooks
    {
        private readonly IObjectContainer objectContainer;
        private IWebDriver _driver;
        private WebDriverWait _wait;
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
            _wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(10));
            _driver.Manage().Window.Maximize();
            _driver.Navigate().GoToUrl("https://www.saucedemo.com/");
            objectContainer.RegisterInstanceAs<IWebDriver>(_driver);
            objectContainer.RegisterInstanceAs<WebDriverWait>(_wait);
            _loginUser = new LoginUser(_driver, _wait);
            _loginUser.Login(_userName, _password);
        }

        [BeforeScenario("@LoginTag")]
        public void BeforeScenario()
        {
            driverBase = new DriverBase();
            _driver = driverBase.Initiate(_browser);
            _wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(10));
            _driver.Manage().Window.Maximize();
            objectContainer.RegisterInstanceAs<IWebDriver>(_driver);
            objectContainer.RegisterInstanceAs<WebDriverWait>(_wait);
        }

        [AfterScenario]
        public void AfterScenario()
        {
           IWebDriver driver = objectContainer.Resolve<IWebDriver>();
            driver.Quit();
        }
    }
}