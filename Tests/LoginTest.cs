using NUnit.Framework;
using OpenQA.Selenium;

[TestFixture]
public class LoginTests : TestBase
{
    [Test]
    public void UserCanLogin()
    {
        driver.Navigate().GoToUrl(ConfigReader.BaseUrl);

        var loginPage = new LoginPage(driver);
        loginPage.Login("sa", "sa");

        Assert.That(driver.Url.Contains("Dashboard"), Is.True);
    }
}