
using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
public class WaitHelper
{
    private IWebDriver driver;

    public WaitHelper(IWebDriver driver)
    {
        this.driver = driver;
    }

    public IWebElement WaitForElement(By locator, int seconds = 10)
    {
        WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(seconds));
        return wait.Until(d => d.FindElement(locator));
    }
}