using OpenQA.Selenium;

namespace TUPEd1.PageElements
{
    public class LoginPageElements
    {
        public readonly IWebDriver driver;

        public LoginPageElements(IWebDriver webDriver)
        {
            driver = webDriver ?? throw new ArgumentNullException(nameof(webDriver));
        }

        // Define elements
        public IWebElement UsernameField => driver.FindElement(By.Id("UserName"));
        public IWebElement PasswordField => driver.FindElement(By.Id("Password"));
        public IWebElement LoginButton => driver.FindElement(By.XPath("//*[@id=\"loginForm\"]/form/div[3]/input[1]"));
    }
}
