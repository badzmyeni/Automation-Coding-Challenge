using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Automation_Coding_Challenge
{
    public class SearchTest
    {

        IWebDriver driver;

        [SetUp]
        public void startBrowser()
        {
            //Open Chrome browser
            driver = new ChromeDriver(",");

            //Maximize the window(broswer)
            driver.Manage().Window.Maximize();
           
        }

        [Test]
        public void test()
        {
            //Navigate to Wikipedia
            driver.Navigate().GoToUrl("https://www.wikipedia.org/");
            Thread.Sleep(2000);

            //Search for the term "Automation testing"
            IWebElement searchBox = driver.FindElement(By.Name("search"));
            searchBox.SendKeys("Automation testing");
            Thread.Sleep(2000);

            //Click the search button
            IWebElement searchButton = driver.FindElement(By.XPath("//*[@id=\"search-form\"]/fieldset/button/i"));
            searchButton.Click();

            Thread.Sleep(2000);
            //Verify that the search results page contains the correct page title "Test automation - Wikipedia" (The text you see in your Chrome tab)
            if (driver.Title == "Test automation - Wikipedia")
            {
                Console.WriteLine("Test Passed: Page title is correct");
            }
            else
            {
                Console.WriteLine("Test Failed: Page title is incorrect");
            }

            Thread.Sleep(2000);
            //Verify that the search result contains the text "Test automation can automate some repetitive but necessary tasks in a formalized testing process"
            IWebElement searchResult = driver.FindElement(By.XPath("//*[contains(text(),'Test automation can automate some repetitive but necessary tasks in a formalized testing process')]"));
            if (searchResult.Text == "Test automation can automate some repetitive but necessary tasks in a formalized testing process.")
            {
                Console.WriteLine("Test Passed: Result contains correct text");
            }
            else
            {
                Console.WriteLine("Test Failed: Result does not contain correct text");
            }
        }


        [TearDown]
        public void closeBrowser()
        {
            driver.Close();
        }

    
    }
}
