using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
public class LoginPage : BasePage
{
    private By username = By.Id("UserName");
    private By password = By.Id("Password");
    private By loginBtn = By.CssSelector(".k-button.k-button-icontext");

    public LoginPage(IWebDriver driver) : base(driver) { }

    public void Login(string user, string pass)
    {
        Type(username, user);
        Type(password, pass);
        Click(loginBtn);
    }
}