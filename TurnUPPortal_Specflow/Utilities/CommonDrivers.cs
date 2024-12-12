using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace TUPEd1.Utilities
{
    public static class CommonDrivers
    {
        // Static WebDriver instance
        public static IWebDriver? driver;

        // Get or initialize the WebDriver
        public static IWebDriver GetDriver()
        {
            if (driver == null)
            {
                driver = new ChromeDriver();
                driver.Manage().Window.Maximize();
            }
            return driver;
        }

        // Quit the WebDriver
        public static void QuitDriver()
        {
            if (driver != null)
            {
                try
                {
                    driver.Quit();
                }
                finally
                {
                    driver = null; // Ensure it's reset
                }
            }
        }

        // Check if the driver is initialized
        public static bool IsDriverInitialized()
        {
            return driver != null;
        }
    }
}
