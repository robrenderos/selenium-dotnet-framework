using NUnit.Framework;
using OpenQA.Selenium;
using AventStack.ExtentReports;
using NUnit.Framework.Interfaces;
using NUnit.Framework;
using NUnit.Allure.Core;

[AllureNUnit]
public class TestBase
{
    protected IWebDriver driver;
    protected ExtentTest _test;

    [OneTimeSetUp]
    public void SetupReporting()
    {
        // This runs ONCE for the whole test suite execution
        Reporter.GetExtent();
    }

    [SetUp]
    public void Setup()
    {
        // Create a test entry in the report using the current test name
        _test = Reporter.CreateTest(TestContext.CurrentContext.Test.Name);

        driver = DriverFactory.GetDriver(
            ConfigReader.Browser, 
            ConfigReader.Headless, 
            ConfigReader.Remote
        );

        driver.Navigate().GoToUrl(ConfigReader.BaseUrl);
    }

    [TearDown]
    public void TearDown()
    {
        var status = TestContext.CurrentContext.Result.Outcome.Status;
        var stacktrace = TestContext.CurrentContext.Result.StackTrace;
        var errorMessage = TestContext.CurrentContext.Result.Message;

        if (status == TestStatus.Failed)
        {
            _test.Fail($"Test Failed: {errorMessage}");
            _test.Fail($"Stacktrace: {stacktrace}");
            // Optional: You can call a screenshot method here and attach it to _test
        }
        else if (status == TestStatus.Passed)
        {
            _test.Pass("Test passed successfully.");
        }

        driver?.Quit();
        
        driver?.Dispose();
    }

    [OneTimeTearDown]
    public void FinalFlush()
    {
        // This is CRITICAL. Without Flush(), the HTML file will be empty.
        Reporter.GetExtent().Flush();
    }
}