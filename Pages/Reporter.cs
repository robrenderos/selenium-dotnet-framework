using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;
using System;
using System.IO;

public static class Reporter
{
    private static ExtentReports _extent;
    private static ExtentTest _test;
    
    public static ExtentReports GetExtent()
    {
        if (_extent == null)
        {
            // Use SparkReporter instead of HtmlReporter
            var reportPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Reports", "Index.html");
            var sparkReporter = new ExtentSparkReporter(reportPath);
            
            _extent = new ExtentReports();
            _extent.AttachReporter(sparkReporter);
            
            // Add environment info from your ConfigReader
            _extent.AddSystemInfo("Environment", ConfigReader.Environment);
            _extent.AddSystemInfo("Browser", ConfigReader.Browser);
        }
        return _extent;
    }

    public static ExtentTest CreateTest(string testName)
    {
        _test = GetExtent().CreateTest(testName);
        return _test;
    }
}