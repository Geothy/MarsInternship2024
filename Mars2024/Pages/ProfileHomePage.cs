using Mars2024.Utilities;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace Mars2024.Pages
{
    public class ProfileHomePage
    {


        public void NavigateToLanguagePanel(IWebDriver driver)
        {
            try
            {
                WaitUtils.WaitToBeVisible(driver, "XPath", "//a[text()='Languages']", 5);
                //navigate to language 
                IWebElement languageTab = driver.FindElement(By.XPath("//a[text()='Languages']"));
                languageTab.Click();
            }
            catch(Exception ex) 
            {
                Assert.Fail("Panel not clickable");
            }
            
        }
        public void NavigateToSkillsPanel(IWebDriver driver)
        {
            WaitUtils.WaitToBeVisible(driver, "XPath", "//a[text()='Skills']", 5);
            //navigate to language 
            IWebElement skillsTab = driver.FindElement(By.XPath("//a[text()='Skills']"));
            skillsTab.Click();

        }

        public void VerifyLoggedInUser(IWebDriver driver)
        {
            //Check if user has loggedin Successfully
            IWebElement checkUser = driver.FindElement(By.XPath("//span[@tabindex='0']"));
            if (checkUser.Text == "Hi Geothy")
            {

                Console.WriteLine("Logged in");

            }
            else
            {
                Console.WriteLine("Not Logged in");
            }
        }
    }
}
