using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using OpenQA.Selenium;
using TUPEd1.PageElements;
using TUPEd1.Utilities;

namespace TUPEd1.Pages
{
    public class EmployeePage
    {
        public readonly IWebDriver driver;
        public readonly EmployeePageElements employeePageElements;
        public readonly TMPageElements tmPageElements;
        public readonly HomePageElements homePageElements;

        public EmployeePage(IWebDriver driver)
        {
            this.driver = driver ?? throw new ArgumentNullException(nameof(driver));

            // Initialize page elements
            employeePageElements = new EmployeePageElements(driver);
            tmPageElements = new TMPageElements(driver);
            homePageElements = new HomePageElements(driver);
        }
       
        public void CreateEmployeeRecord(string name, string username, string password)
        {
            try
            {
                Wait.UntilElementIsVisible(employeePageElements.createButton);
                employeePageElements.createButton.Click();
            }
            catch(Exception ex)
            {
                TestContext.WriteLine($"Element not found: {ex.Message}");
                Assert.Fail("Create button hasn't been found.");

            }
            try
            {
                Wait.UntilElementIsVisible(employeePageElements.nameTextbox);
                employeePageElements.nameTextbox.SendKeys(name);
            }
            catch (Exception ex)
            {
                TestContext.WriteLine($"Element not found: {ex.Message}");
                Assert.Fail("name textbox hasn't been found.");

            }
            Wait.UntilElementIsVisible(employeePageElements.usernameTextbox);
            employeePageElements.usernameTextbox.SendKeys(username);
            Wait.UntilElementIsVisible(employeePageElements.passwordTextbox);
            employeePageElements.passwordTextbox.SendKeys(password);
            Wait.UntilElementIsVisible(employeePageElements.reTypePasswordTextbox);
            employeePageElements.reTypePasswordTextbox.SendKeys(password);

            Wait.UntilElementIsClickable(employeePageElements.isAdminCheckbox);
            employeePageElements.isAdminCheckbox.Click();
            Wait.UntilElementIsClickable(employeePageElements.saveButton);
            employeePageElements.saveButton.Click();

            homePageElements.administrationTab.Click();
            Wait.UntilElementIsVisible(homePageElements.employeeOption);

            homePageElements.employeeOption.Click();

            Wait.UntilElementIsInteractable(tmPageElements.lastPageButton);
        
        }
        public string GetName()
        {

            TestContext.WriteLine("getting name text");
            // driver.Manage().Timeouts().PageLoad = TimeSpan.FromSeconds(100);
            //WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(100));
            Wait.UntilElementIsPresent(employeePageElements.nameInTableRow);
            Wait.UntilElementIsVisible(employeePageElements.nameInTableRow);
            return employeePageElements.nameInTableRow.Text;

        }

        public void EditEmployeeRecord(string editedName, string editedUsername, string editedPassword)
        {
            Wait.UntilElementIsPresent(employeePageElements.editButton);
            Wait.UntilElementIsClickable(employeePageElements.editButton);
            employeePageElements.editButton.Click();

            Wait.UntilElementIsVisible(employeePageElements.nameTextbox);
            employeePageElements.nameTextbox.Clear();
            employeePageElements.nameTextbox.SendKeys(editedName);

            Wait.UntilElementIsInteractable(employeePageElements.usernameTextbox);
            employeePageElements.usernameTextbox.Clear();
            employeePageElements.usernameTextbox.SendKeys(editedUsername);

            Wait.UntilElementIsInteractable(employeePageElements.passwordTextbox);
            employeePageElements.passwordTextbox.Clear();
            employeePageElements.passwordTextbox.SendKeys(editedPassword);

            Wait.UntilElementIsInteractable(employeePageElements.reTypePasswordTextbox);
            employeePageElements.reTypePasswordTextbox.Clear();
            employeePageElements.reTypePasswordTextbox.SendKeys(editedPassword);

            Wait.UntilElementIsClickable(employeePageElements.saveButton);
            employeePageElements.saveButton.Click();

            homePageElements.administrationTab.Click();
            Wait.UntilElementIsVisible(homePageElements.employeeOption);

            homePageElements.employeeOption.Click();

            Wait.UntilElementIsInteractable(tmPageElements.lastPageButton);

        }

        public string GetEditedName()
        {
            TestContext.WriteLine("Getting edited employee name");
            Wait.UntilElementIsPresent(employeePageElements.nameInTableRow);
            Wait.UntilElementIsVisible(employeePageElements.nameInTableRow);
            return employeePageElements.nameInTableRow.Text;

        }

        public void DeleteEmployeeRecord()
        {
            Wait.UntilElementIsPresent(employeePageElements.deleteButton);
            Wait.UntilElementIsClickable(employeePageElements.deleteButton);
            employeePageElements.deleteButton.Click();

            Wait.UntilAlertIsPresent();

            //Click OK to delete
            driver.SwitchTo().Alert().Accept();

            Thread.Sleep(3000);

            driver.Navigate().Refresh();

            //Check if the record is deleted

            tmPageElements.lastPageButton.Click();
            Thread.Sleep(3000);
        }
         public string GetDeletedName()
        {
            Wait.UntilElementIsVisible(employeePageElements.nameInTableRow);
            return employeePageElements.nameInTableRow.Text;
        }

    }


    }
