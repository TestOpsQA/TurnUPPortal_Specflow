using OpenQA.Selenium;
using TUPEd1.PageElements;
using TUPEd1.Utilities;

namespace TUPEd1.Pages
{
    public class LoginPage
    {
        public readonly IWebDriver driver;
        public readonly LoginPageElements loginPageElements;

        public LoginPage(IWebDriver driver)
        {
            this.driver = driver ?? throw new ArgumentNullException(nameof(driver));

            // Initialize page elements
            loginPageElements = new LoginPageElements(driver);
        }

        // Actions
        public void EnterUsername()
        {
            Wait.UntilElementIsVisible(loginPageElements.UsernameField);
            loginPageElements.UsernameField.Clear();
            loginPageElements.UsernameField.SendKeys("hari");
        }

        public void EnterPassword()
        {
            Wait.UntilElementIsVisible(loginPageElements.PasswordField);
            loginPageElements.PasswordField.Clear();
            loginPageElements.PasswordField.SendKeys("123123");
        }

        public void ClickLoginButton()
        {
            Wait.UntilElementIsClickable(loginPageElements.LoginButton);
            loginPageElements.LoginButton.Click();
        }
    }
}
