using Mars2024.Utilities;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mars2024.Pages
{
    public class LanguagePage
    {

        private readonly By addNewLangButtonLocator = By.CssSelector("div[class='ui teal button ']");
        IWebElement addNewLangButton;
        private readonly By languageTextboxLocator = By.XPath("//input[@type='text'][@placeholder='Add Language']");
        IWebElement languageTextbox;
        private readonly By selectLangLevelOptionLocator = By.XPath("//option[contains(text(),'Fluent')]");
        IWebElement selectLangLevelOption;
        IWebElement editLangTextbox;
        private readonly By editLangTextboxLocator = By.XPath("//input[@placeholder='Add Language']");
        public void AddLanguage(IWebDriver driver, string language)
        { //Add new language
            addNewLangButton = driver.FindElement(addNewLangButtonLocator);
            addNewLangButton.Click();
            Console.WriteLine("add btn clicked");
            WaitUtils.WaitToBeClickable(driver, "xpath", "//input[@type='text'][@placeholder='Add Language']", 5);
            //Enter language 
            languageTextbox = driver.FindElement(languageTextboxLocator);
            languageTextbox.SendKeys(language);

            IWebElement chooseLangLevelDropdown = driver.FindElement(By.XPath("//option[text()='Choose Language Level']"));
            chooseLangLevelDropdown.Click();

            //choose language level from dropdown
            selectLangLevelOption = driver.FindElement(selectLangLevelOptionLocator);
            selectLangLevelOption.Click();

            //click on add button
            IWebElement addLangButton = driver.FindElement(By.XPath("//input[@value='Add']"));
            addLangButton.Click();

            WaitUtils.WaitToBeVisible(driver, "XPath", "//td[text()='English']", 5);
            //check if language is added
            IWebElement newLangAdded = driver.FindElement(By.XPath("//td[text()='English']"));
            if (newLangAdded.Text == "English")
            {
                Console.WriteLine("New Lang added");
            }
            else
            {
                Console.WriteLine("New Lang not added");
            }

        }
        public void EditLanguage(IWebDriver driver)
        {
            WaitUtils.WaitToBeClickable(driver, "xpath", "//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/table/tbody/tr/td[3]/span[1]/i", 5);
            IWebElement editNewLangButton = driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/table/tbody/tr/td[3]/span[1]/i"));

            editNewLangButton.Click();
            Console.WriteLine("edit btn clicked");
            WaitUtils.WaitToBeClickable(driver, "xpath", "//input[@placeholder='Add Language']", 7);
            //Enter language 
            editLangTextbox = driver.FindElement(editLangTextboxLocator);
            editLangTextbox.Clear();
            editLangTextbox.SendKeys("Manglish");
            //choose language level from dropdown
            IWebElement editselectLangLevelOption = driver.FindElement(By.Name("level"));
            editselectLangLevelOption.Click();
            Thread.Sleep(1000);
            //click on add button
            IWebElement updateLangButton = driver.FindElement(By.XPath("//input[@value='Update']"));
            updateLangButton.Click();
            WaitUtils.WaitToBeVisible(driver, "xpath", "//td[text()='Manglish']", 5);
            IWebElement editLangAdded = driver.FindElement(By.XPath("//td[text()='Manglish']"));
            if (editLangAdded.Text == "Manglish")
            {
                Console.WriteLine("Lang updated");
            }
            else
            {
                Console.WriteLine("Lang not updated");
            }
        }
        public void RemoveLanguage(IWebDriver driver)
        {
            IWebElement deleteLangButton = driver.FindElement(By.CssSelector("i[class='remove icon']"));
            deleteLangButton.Click();
            WaitUtils.WaitToBeVisible(driver, "cssselector", "div[class='ns-box-inner']",10);
            IWebElement deleteLangAdded = driver.FindElement(By.CssSelector("div[class='ns-box-inner']"));
            if (deleteLangAdded.Text == "Manglish")
            {
                Console.WriteLine("Lang not deleted");
            }
            else
            {
                Console.WriteLine("Lang deleted");
            }

        }






    }
}
