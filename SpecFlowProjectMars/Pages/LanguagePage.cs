﻿using NUnit.Framework;
using OpenQA.Selenium;
using SpecFlowProjectMars.Utilities;

namespace SpecFlowProjectMars.Pages
{
    public class LanguagePage : CommonDriver
    {
        private static IWebElement addNewLangButton => driver.FindElement(By.XPath("//div[contains(text(),'Add New')]"));
        private static IWebElement languageTextbox => driver.FindElement(By.XPath("//input[@type='text'][@placeholder='Add Language']"));
        private static IWebElement selectLangLevelOption => driver.FindElement(By.XPath("//option[contains(text(),'Basic')]"));
        private static IWebElement addLangButton => driver.FindElement(By.XPath("//input[@value=\"Add\"]"));
        private static IWebElement popupmsg => driver.FindElement(By.CssSelector("div[class='ns-box-inner']"));
        private static IWebElement editNewLangButton => driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/table/tbody/tr/td[3]/span[1]/i"));
        private static IWebElement editLangTextbox => driver.FindElement(By.XPath("//input[@placeholder='Add Language']"));
        private static IWebElement editselectLangLevelOption => driver.FindElement(By.Name("level"));
        private static IWebElement updateLangButton => driver.FindElement(By.XPath("//input[@value='Update']"));
        private static IWebElement editLangAdded => driver.FindElement(By.XPath("//td[text()='Manglish']"));
        private static IWebElement deleteLangButton => driver.FindElement(By.CssSelector("i[class='remove icon']"));
        private static IWebElement deleteLangAdded => driver.FindElement(By.CssSelector("div[class='ns-box-inner']"));
             
      public void ClearData()
        {
            try
            {                
                var deleteButton = driver.FindElements(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/table/tbody/tr/td[3]/span[2]/i"));
                foreach (var button in deleteButton)
                {
                    button.Click();
                }
            }
            catch(NoSuchElementException) 
            {
                Console.WriteLine("Nothing to delete");
            }

        }
        public void AddLanguage(IWebDriver driver, string language, string level)
        {
            //Add new language
            addNewLangButton.Click();
            //Enter language 
            languageTextbox.SendKeys(language);
            //choose language level from dropdown
            selectLangLevelOption.Click();
           //click on add button
            addLangButton.Click();
        }
        public void AddLanguageAssertion(IWebDriver driver, string language)
        {
            //check if language is added
            Thread.Sleep(1000);
            string verifyLang = language + " has been added to your languages";
            Assert.AreEqual(verifyLang,popupmsg.Text);
        }
        public void EditLanguage(IWebDriver driver)
        {
            editNewLangButton.Click();
            //Enter language 
            editLangTextbox.Clear();
            editLangTextbox.SendKeys("Manglish");
            //choose language level from dropdown
            editselectLangLevelOption.Click();
            Thread.Sleep(1000);
            //click on add button
            updateLangButton.Click();
        }
        public void EditLanguageAssert(IWebDriver driver)
        {
            Thread.Sleep(1000);
            Assert.That(editLangAdded.Text == "Manglish", "Lang not updated");
        }
        public void RemoveLanguage(IWebDriver driver)
        {
            deleteLangButton.Click();
        }
        public void RemoveLanguageAssert(IWebDriver driver)
        {
            // WaitUtils.WaitToBeVisible(driver, "cssselector", "div[class='ns-box-inner']", 10);
            Thread.Sleep(1000);
            Assert.That(deleteLangAdded.Text != "Manglish", "Lang not deleted");
        }
    }
}
