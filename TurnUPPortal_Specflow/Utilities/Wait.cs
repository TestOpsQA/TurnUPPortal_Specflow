using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;

namespace TUPEd1.Utilities
{
    public class Wait
    {
        private const int DefaultTimeoutInSeconds = 200;

        /// <summary>
        /// Waits until the specified WebElement is visible on the page.
        /// </summary>
        public static void UntilElementIsVisible(IWebElement element)
        {
            EnsureDriverIsInitialized();
            WebDriverWait wait = new WebDriverWait(CommonDrivers.driver, TimeSpan.FromSeconds(DefaultTimeoutInSeconds));
            wait.Until(driver => element.Displayed);
        }

        /// <summary>
        /// Waits until the specified WebElement is clickable.
        /// </summary>
        public static void UntilElementIsClickable(IWebElement element)
        {
            EnsureDriverIsInitialized();
            WebDriverWait wait = new WebDriverWait(CommonDrivers.driver, TimeSpan.FromSeconds(DefaultTimeoutInSeconds));
            wait.Until(driver => element.Enabled && element.Displayed);
        }
        public static void UntilElementIsPresent(IWebElement element)
        {
            EnsureDriverIsInitialized();
            WebDriverWait wait = new WebDriverWait(CommonDrivers.driver, TimeSpan.FromSeconds(DefaultTimeoutInSeconds));
            wait.Until(driver => element != null);
        }

        public static void UntilElementIsInteractable(IWebElement element)
        {
            EnsureDriverIsInitialized();
            WebDriverWait wait = new WebDriverWait(CommonDrivers.driver, TimeSpan.FromSeconds(DefaultTimeoutInSeconds));

            // Wait until the element is visible, enabled, and stable for interaction
            wait.Until(driver =>
                element.Displayed &&    // Element is visible
                element.Enabled &&      // Element is enabled
                IsElementReadyForInteraction(driver, element) // Element is stable for interaction
            );
        }

        // Helper method to ensure the element is stable for interaction
        private static bool IsElementReadyForInteraction(IWebDriver driver, IWebElement element)
        {
            try
            {
                // Check if the element is still visible and enabled
                return element.Displayed && element.Enabled;
            }
            catch (StaleElementReferenceException)
            {
                // The element might have become stale during the interaction
                return false;
            }
        }
        public static void UntilAlertIsPresent()
        {
            EnsureDriverIsInitialized();
            WebDriverWait wait = new WebDriverWait(CommonDrivers.driver, TimeSpan.FromSeconds(DefaultTimeoutInSeconds));
            wait.Until(driver =>
            {
                try
                {
                    // Try to switch to the alert to see if it's present
                    IAlert alert = driver.SwitchTo().Alert();
                    return alert != null;
                }
                catch (NoAlertPresentException)
                {
                    return false; // Alert is not present
                }
            });
        }
        private static void EnsureDriverIsInitialized()
        {
            if (CommonDrivers.driver == null)
            {
                throw new InvalidOperationException("WebDriver is not initialized. Call InitializeDriver first.");
            }
        }
    }
}
