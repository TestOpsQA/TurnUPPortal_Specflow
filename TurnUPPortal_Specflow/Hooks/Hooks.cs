
using TechTalk.SpecFlow;
using TUPEd1.Utilities;

namespace TUPEd1.Hooks
{
    [Binding]
    public class Hooks
    {
        [BeforeScenario]
        public static void BeforeScenario()
        {
            // Initialize the WebDriver
            var driver = CommonDrivers.GetDriver();

            // Navigate to the test URL
            driver.Navigate().GoToUrl("http://horse.industryconnect.io/Account/Login?ReturnUrl=%2f");
        }

      /// <summary>
       [AfterScenario]
    
       public static void AfterScenario()
       {
            // Quit the WebDriver after each scenario
            CommonDrivers.QuitDriver();
        }
    }
}
