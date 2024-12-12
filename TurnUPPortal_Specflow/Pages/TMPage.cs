using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using TUPEd1.PageElements;
using TUPEd1.Utilities;

namespace TUPEd1.Pages
{
    public class TMPage
    {

        public readonly IWebDriver driver;
        public readonly TMPageElements tmPageElements;
        //public string Code = "";
        // public string Description = "";
        //public string Price="";

        public TMPage(IWebDriver driver)
        {
            this.driver = driver ?? throw new ArgumentNullException(nameof(driver));

            // Initialize page elements
            tmPageElements = new TMPageElements(driver);
        }

        public void createTimeRecord(string code, string description, string price)
        {
            try
            {
                // Access elements through the tmPageElements instance
                Wait.UntilElementIsVisible(tmPageElements.createNewButton);
                tmPageElements.createNewButton.Click();
            }
            catch (Exception ex)
            {
                TestContext.WriteLine($"Element not found: {ex.Message}");
                Assert.Fail("Create New button hasn't been found.");
            }
            try
            {
                // Access elements through the tmPageElements instance
                Wait.UntilElementIsVisible(tmPageElements.typeCodeDropdown);
                tmPageElements.typeCodeDropdown.Click();
            }
            catch (Exception ex)
            {
                TestContext.WriteLine($"Element not found: {ex.Message}");
                Assert.Fail("type code drop down hasn't been found.");
            }

            Wait.UntilElementIsVisible(tmPageElements.timeOption);
            tmPageElements.timeOption.Click();
            // Type code into Code textbox
            // Code = tmPageElements.code;
            tmPageElements.codeTextbox.SendKeys(code);
            // Description = tmPageElements.description;

            // Type description into Description textbox
            tmPageElements.descriptionTextbox.SendKeys(description);

            // Type price into Price textbox
            tmPageElements.priceTagOverlap.Click();
            //Price = tmPageElements.price;
            tmPageElements.priceTextbox.SendKeys(price);
            Wait.UntilElementIsClickable(tmPageElements.saveButton);
            // Click on Save button
            tmPageElements.saveButton.Click();
            //driver.Manage().Timeouts().PageLoad = TimeSpan.FromSeconds(100);
        }
        public void goToLastPage()
        {

            if (((IJavaScriptExecutor)driver).ExecuteScript("return document.readyState").ToString() == "complete")
            {
                try
                {  // Page is fully loaded, wait for the last page button to be clickable
                    /// var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(100));
                    ///wait.Until(driver => tmPageElements.lastPageButton.Displayed && tmPageElements.lastPageButton.Enabled);
                    Thread.Sleep(5000);
                    tmPageElements.lastPageButton.Click();
                    Thread.Sleep(4000);
                    tmPageElements.lastPageButton.Click();

                }

                /*  var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(50));
                 wait.Until(driver => ((IJavaScriptExecutor)driver).ExecuteScript("return document.readyState").ToString() == "complete");
                 wait.Until(driver => driver.FindElements(By.TagName("tr")).Count > 0);
                 try
                 {
                     // Create a WebDriverWait instance
                     /* var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(30));

                      // **Condition: Wait for the entire page to fully load**
                      wait.Until(driver =>
                          ((IJavaScriptExecutor)driver).ExecuteScript("return document.readyState").ToString() == "complete");
                      //tr
                      wait.Until(driver => driver.FindElements(By.TagName("tr")).Count > 0);
                      // Wait until the last page button is both visible and clickable
                      wait.Until(driver =>
                          tmPageElements.lastPageButton.Displayed && tmPageElements.lastPageButton.Enabled);

                      // Click the last page button*/
                /// tmPageElements.lastPageButton.Click();

                catch (Exception ex)
                {
                    TestContext.WriteLine($"Element not found: {ex.Message}");
                    Assert.Fail("last page button hasn't been found.");
                }
            }
            else
            {
                Assert.Fail("unable to go to last page");
            }
        }
        public string GetCode()
        {
            TestContext.WriteLine("getting code text");
            // driver.Manage().Timeouts().PageLoad = TimeSpan.FromSeconds(100);
            //WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(100));
            Wait.UntilElementIsPresent(tmPageElements.codeInRow);
            Wait.UntilElementIsVisible(tmPageElements.codeInRow);
            return tmPageElements.codeInRow.Text;

            //TestContext.WriteLine($"Element not found: {ex.Message}");
            // Assert.Fail("code in the last row hasn't been found.");


        }
        // Get Description from the last row
        public string GetDescription()
        {
            TestContext.WriteLine("getting description text");
            return tmPageElements.descriptionInRow.Text;
        }

        // Get Price from the last row
        public string GetPrice()
        {
            TestContext.WriteLine("getting price text");
            return tmPageElements.priceInRow.Text;
        }
        public void EditTimeRecord(string editedCode, string editedDescription, string editedPrice)
        {


            Wait.UntilElementIsVisible(tmPageElements.editButton);
            Wait.UntilElementIsClickable(tmPageElements.editButton);
            tmPageElements.editButton.Click();

            Wait.UntilElementIsVisible(tmPageElements.codeTextbox);
            tmPageElements.codeTextbox.Clear();
            tmPageElements.codeTextbox.SendKeys(editedCode);

            Wait.UntilElementIsVisible(tmPageElements.descriptionTextbox);
            tmPageElements.descriptionTextbox.Clear();
            tmPageElements.descriptionTextbox.SendKeys(editedDescription);

            Wait.UntilElementIsClickable(tmPageElements.priceTagOverlap);

            tmPageElements.priceTagOverlap.Click();

            // Wait for the second element (priceTextbox) to be interactable
            Wait.UntilElementIsInteractable(tmPageElements.priceTextbox);

            // Click and clear the text box to ensure it's ready for input
            tmPageElements.priceTextbox.Click();
            tmPageElements.priceTextbox.Clear();
            Thread.Sleep(3000);
            tmPageElements.priceTagOverlap.Click();
            tmPageElements.priceTextbox.Click();

            // Add an additional check for interactability before sending keys
            Wait.UntilElementIsInteractable(tmPageElements.priceTextbox);
            tmPageElements.priceTextbox.SendKeys(editedPrice);


            Wait.UntilElementIsVisible(tmPageElements.saveButton);
            tmPageElements.saveButton.Click();
            Thread.Sleep(5000);
            Wait.UntilElementIsVisible(tmPageElements.lastPageButton);
            tmPageElements.lastPageButton.Click();
        }
        public string GetEditedCode()
        {

            return tmPageElements.codeInRow.Text;
        }

        public string GetEditedDescription()
        {

            return tmPageElements.descriptionInRow.Text;
        }
        public string GetEditedPrice()
        {

            return tmPageElements.priceInRow.Text;
        }

        public void DeleteTimeRecord()
        {
            Wait.UntilElementIsVisible(tmPageElements.deleteButton);
            tmPageElements.deleteButton.Click();

            Wait.UntilAlertIsPresent();

            //Click OK to delete
            driver.SwitchTo().Alert().Accept();

            Thread.Sleep(3000);

            driver.Navigate().Refresh();

            //Check if the record is deleted
          
           tmPageElements.lastPageButton.Click();
            Thread.Sleep(3000);
        }
        public string GetDeletedCode()
        {
           
            Wait.UntilElementIsVisible(tmPageElements.codeInRow);
            return tmPageElements.codeInRow.Text;
            
        }
    } }