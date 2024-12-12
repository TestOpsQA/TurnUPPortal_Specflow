using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using TUPEd1.PageElements;
using TUPEd1.Utilities;


namespace TUPEd1.Pages
{
    public class HomePage
    {
        public readonly IWebDriver driver;
        public readonly HomePageElements homePageElements;

        public HomePage(IWebDriver driver)
        {
            this.driver = driver ?? throw new ArgumentNullException(nameof(driver));

            // Initialize page elements
            homePageElements = new HomePageElements(driver);
        }

        public void NaviagateToTMPage()
        {
            homePageElements.administrationTab.Click();
            Wait.UntilElementIsClickable(homePageElements.timeAndMaterialOption);
            homePageElements.timeAndMaterialOption.Click();
        }
        public void NavigateToEmployeePage()
        {
            Wait.UntilElementIsVisible(homePageElements.administrationTab);
            Wait.UntilElementIsClickable(homePageElements.administrationTab);
            homePageElements.administrationTab.Click();

            Wait.UntilElementIsClickable(homePageElements.employeeOption);
            homePageElements.employeeOption.Click();
        }
    }
}
