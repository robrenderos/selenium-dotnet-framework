using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System; // For TimeSpan
using OpenQA.Selenium.Support.UI; // For WebDriverWait
public class BasePage
{
    protected IWebDriver driver;

    public BasePage(IWebDriver driver)
    {
        this.driver = driver;
    }

    protected IWebElement WaitForElement(By locator)
{
    WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
    return wait.Until(d => d.FindElement(locator));
}

   
protected void Click(By locator)
{
    WaitForElement(locator).Click();
}

    protected void Type(By locator, string text)
    {
        driver.FindElement(locator).SendKeys(text);
    }
}