using System.Diagnostics;
using NUnit.Framework;
using OpenQA.Selenium;
using TechTalk.SpecFlow;
using TUPEd1.Pages;
using TUPEd1.Utilities;


namespace TUPEd1.StepDefinitions
{
    [Binding]
    public class StepDefinitions
    {
        private readonly IWebDriver driver;
        private readonly LoginPage loginPage;
        private readonly HomePage homePage;
        private readonly TMPage tmPage;
        private readonly EmployeePage employeePage;

        public StepDefinitions()
        {
            driver = CommonDrivers.driver ?? throw new InvalidOperationException("WebDriver is not initialized.");
            loginPage = new LoginPage(driver);
            homePage = new HomePage(driver);
            tmPage = new TMPage(driver);
            employeePage = new EmployeePage(driver);
        }

        [Given(@"User logged in to the TurnUp portal")]
        public void GivenUserLoggedInToTheTurnUpPortal()
        {
            loginPage.EnterUsername();
            loginPage.EnterPassword();
            loginPage.ClickLoginButton();
        }


        [Given(@"user navigates to Time and Material page")]
        public void GivenUserNavigatesToTimeAndMaterialPage()
        {
            homePage.NaviagateToTMPage();
        }

        [When(@"user creates a Time record using valid '([^']*)', '([^']*)' and '([^']*)' data")]
        public void WhenUserCreatesATimeRecordUsingValidAndData(string code, string description, string price)
        {
          
            tmPage.createTimeRecord(code,description,price);
            tmPage.goToLastPage();
        }


        [Then(@"The time record is created successfully with valid '([^']*)', '([^']*)' and '([^']*)' data")]
        public void ThenTheTimeRecordIsCreatedSuccessfullyWithValidAndData(string code, string description, string price)
        {
           string newCode = tmPage.GetCode();
           string newDescription = tmPage.GetDescription();
           string newPrice = tmPage.GetPrice();
            TestContext.WriteLine(newPrice);

            Assert.That(newCode == code, "Actual Code and expected Code do not match.");
            Assert.That(newDescription == description, "Actual Description and expected Description do not match.");
            Assert.That(newPrice == "$" + price + ".00", "Actual Price and expected Price do not match.");
        }

        [When(@"user edits the created Time record with valid '([^']*)', '([^']*)' and '([^']*)' data")]
        public void WhenUserEditsTheCreatedTimeRecordWithValidAndData(string EditedCode, string EditedDescription, string EditedPrice)
        {
            tmPage.goToLastPage();
            tmPage.EditTimeRecord(EditedCode, EditedDescription, EditedPrice);
        }

        [Then(@"the record is edited successfully with valid '([^']*)', '([^']*)' and '([^']*)' data")]
        public void ThenTheRecordIsEditedSuccessfullyWithValidAndData(string EditedCode, string EditedDescription, string EditedPrice)
        {
            tmPage.goToLastPage();
            string editedCode = tmPage.GetEditedCode();
            string editedDescription = tmPage.GetEditedDescription();
            string editedPrice = tmPage.GetEditedPrice();

            //recheck code and description
            Assert.That(editedCode == EditedCode, "Expected Edited Code and actual edited code do not match.");
            Assert.That(editedDescription == EditedDescription, "Expected Edited Description and actual edited description do not match.");
            Assert.That(editedPrice == "$" + EditedPrice + ".00", "Expected Edited Price and actual edited price do not match.");
        }

        [When(@"user deletes the edited Time record")]
        public void WhenUserDeletesTheEditedTimeRecord()
        {
            tmPage.goToLastPage();
            tmPage.DeleteTimeRecord();
        }

        [Then(@"The time record is deleted and does not contain '([^']*)'")]
        public void ThenTheTimeRecordIsDeletedAndDoesNotContain(string EditedCode)
        {
            tmPage.goToLastPage();
            string deletedCode= tmPage.GetEditedCode();
            Assert.That(deletedCode != EditedCode, "The record is not deleted");
        }

        [Given(@"user navigates to Employee page")]
        public void GivenUserNavigatesToEmployeePage()
        {
            homePage.NavigateToEmployeePage();

        }
        [When(@"user creates an employee record with valid '([^']*)', '([^']*)', and <'([^']*)'")]
        public void WhenUserCreatesAnEmployeeRecordWithValidAnd(string name, string userName, string password)
        {
           
            employeePage.CreateEmployeeRecord(name, userName, password);
            tmPage.goToLastPage();

        }

        [Then(@"Employee record must be successfully created with '([^']*)' data") ]
        public void ThenEmployeeRecordMustBeSuccessfullyCreatedWithData(string newName)
        {
            string newNameCreated = employeePage.GetName();
            Assert.That(newNameCreated == newName, "Then actual employee name and expaected employee name does not match"); ;
        }

        [When(@"user edits the employee record with valid '([^']*)', '([^']*)', and '([^']*)'")]
        public void WhenUserEditsThEmployeeRecordWithValidAnd(string editedName, string editedUsername, string editedPassword)
        {
            
                tmPage.goToLastPage();
                employeePage.EditEmployeeRecord(editedName, editedUsername, editedPassword);
            
        }
        [Then(@"employee record must be edited successfully with '([^']*)' data")]
        public void ThenEmployeeRecordMustBeEditedSuccessfullyWithData(string editedName)
            { 
            tmPage.goToLastPage();
            string EditedName = employeePage.GetEditedName();
            Assert.That(EditedName == editedName, "The actual edited name and the expaected edited name does not match");
        }

        [When(@"user deletes an employee record")]
        public void WhenUserDeletesAnEmployeeRecord()
        {
            tmPage.goToLastPage();
            employeePage.DeleteEmployeeRecord();

        }

        [Then(@"the record is deleted successfully and the employees table must not contain '([^']*)' record")]
        public void ThenTheRecordIsDeletedSuccessfullyAndTheEmployeesTableMustNotContainRecord(string editedName)
        {
            tmPage.goToLastPage();
            string DeletedName = employeePage.GetDeletedName();
            Assert.That(DeletedName != editedName, "The record is not deleted");

        }



    }
}
