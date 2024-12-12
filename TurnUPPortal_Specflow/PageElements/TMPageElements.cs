using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;

namespace TUPEd1.PageElements
{
    public class TMPageElements
    {
        public readonly IWebDriver driver;
        public TMPageElements(IWebDriver webDriver)
        {
            driver = webDriver ?? throw new ArgumentNullException(nameof(webDriver));
        }
        public IWebElement createNewButton => driver.FindElement(By.XPath("//*[@id=\"container\"]/p/a"));
        public IWebElement lastPageButton => driver.FindElement(By.XPath("//span[contains(text(),'Go to the last page')]"));
        public IWebElement typeCodeDropdown => driver.FindElement(By.XPath("//*[@id=\"TimeMaterialEditForm\"]/div/div[1]/div/span[1]/span/span[2]/span"));
        public IWebElement timeOption => driver.FindElement(By.XPath("//*[@id=\"TypeCode_listbox\"]/li[2]"));
        public IWebElement codeTextbox => driver.FindElement(By.Id("Code"));
        public IWebElement descriptionTextbox =>driver.FindElement(By.Id("Description"));
        public IWebElement priceTagOverlap => driver.FindElement(By.XPath("//*[@id=\"TimeMaterialEditForm\"]/div/div[4]/div/span[1]/span/input[1]"));
        public IWebElement priceTextbox => driver.FindElement(By.Id("Price"));
        public IWebElement saveButton => driver.FindElement(By.Id("SaveButton"));
        public IWebElement codeInRow => driver.FindElement(By.XPath("//*[@id=\"tmsGrid\"]/div[3]/table/tbody/tr[last()]/td[1]"));
        public IWebElement descriptionInRow => driver.FindElement(By.XPath("//*[@id=\"tmsGrid\"]/div[3]/table/tbody/tr[last()]/td[3]"));
        public IWebElement priceInRow => driver.FindElement(By.XPath("//*[@id=\"tmsGrid\"]/div[3]/table/tbody/tr[last()]/td[4]"));
        public IWebElement editButton => driver.FindElement(By.XPath("//*[@id=\"tmsGrid\"]/div[3]/table/tbody/tr[last()]/td[5]/a[1]"));
        public IWebElement deleteButton => driver.FindElement(By.XPath("//*[@id=\"tmsGrid\"]/div[3]/table/tbody/tr[last()]/td[5]/a[2]"));

    }
}
