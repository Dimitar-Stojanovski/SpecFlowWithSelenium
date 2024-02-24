using AventStack.ExtentReports;
using AventStack.ExtentReports.Gherkin.Model;
using AventStack.ExtentReports.Reporter;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace SpecFlowWithSelenium.Helpers
{
    public class Reporting
    {
        private static ExtentReports extentReports;
        private static ExtentTest extentTest;

        private static ExtentReports StartReporting()
        {
            var path = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) + @"+ @""..\..\..\..\Utils\TestResults";

            if (extentReports == null)
            {
                Directory.CreateDirectory(path);
                extentReports = new ExtentReports();
                var htmlReporter = new ExtentSparkReporter(path);
                extentReports.AttachReporter(htmlReporter);
                
            }
            return extentReports;
        }

        public static void CreateTest(string _name)
        {
            extentTest = StartReporting().CreateTest(_name);
        }

        private static void EndTest(string info, string screenshot)
        {
            extentTest.Info(info, MediaEntityBuilder.CreateScreenCaptureFromBase64String(screenshot).Build());
        }

        private static string addScrenshot(IWebDriver driver)
        {
            ITakesScreenshot screenshot= (ITakesScreenshot)driver;
            var file= screenshot.GetScreenshot();
            var img = file.AsBase64EncodedString;
            return img;
        }

        public static void ExtentReportLoging(ScenarioContext scenarioContext,string info, string screenshot, IWebDriver driver)
        {
            string stepType = scenarioContext.StepContext.StepInfo.StepDefinitionType.ToString();
            string stepName = scenarioContext.StepContext.StepInfo.Text;
            string errorMsg = scenarioContext.TestError.Message;

            if (scenarioContext.TestError is null)
            {
                if (stepType == "Given")
                {
                    extentTest.CreateNode<Given>(stepName);
                }
                else if (stepType == "When")
                {
                    extentTest.CreateNode<When>(stepName);
                }
                else if (stepType == "And")
                {
                    extentTest.CreateNode<And>(stepName);
                }
                else if (stepType == "Then")
                {
                    extentTest.CreateNode<Then>(stepName);
                }
            }

            // For failed scenarios
            if(scenarioContext.TestError != null)
            {
                if (stepType == "Given")
                {
                    extentTest.CreateNode<Given>(stepName).Fail(errorMsg, MediaEntityBuilder.CreateScreenCaptureFromPath(addScrenshot(driver)).Build());
                }
                else if(stepType == "When")
                {
                    extentTest.CreateNode<When>(stepName).Fail(errorMsg, MediaEntityBuilder.CreateScreenCaptureFromPath(addScrenshot(driver)).Build());
                }
                else if(stepType == "And")
                {
                    extentTest.CreateNode<And>(stepName).Fail(errorMsg, MediaEntityBuilder.CreateScreenCaptureFromPath(addScrenshot(driver)).Build());
                }
                else if (stepType == "Then")
                {
                    extentTest.CreateNode<And>(stepName).Fail(errorMsg, MediaEntityBuilder.CreateScreenCaptureFromPath(addScrenshot(driver)).Build());
                }
            }
        }
    }
}
