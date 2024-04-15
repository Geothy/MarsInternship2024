using Mars2024.Utilities;
using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mars2024.Pages
{
    public class SkillsPage
    {
        private readonly By addNewSkillButtonLocator = By.CssSelector("div[class='ui teal button']");
        IWebElement addNewSkillButton;
        private readonly By skillsTextboxLocator = By.XPath("//input[@type='text'][@placeholder='Add Skill']");
        IWebElement skillsTextbox;
        private readonly By skillLevelOptionLocator = By.XPath("//option[text()='Intermediate']");
        IWebElement skillLevelOption;
        private readonly By editSkillTextboxLocator = By.XPath("//input[@placeholder='Add Skill']");
        IWebElement editSkillTextbox;
        private readonly By editSkillLevelLocator = By.XPath("//option[text()='Beginner']");
        IWebElement editSkillLevel;

        public void AddSkills(IWebDriver driver, string skills)
        { //Add new language
            addNewSkillButton = driver.FindElement(addNewSkillButtonLocator);
            addNewSkillButton.Click();
            Console.WriteLine("Skill add btn clicked");
            WaitUtils.WaitToBeClickable(driver, "xpath", "//input[@type='text'][@placeholder='Add Skill']", 5);
            //Enter language 
            skillsTextbox = driver.FindElement(skillsTextboxLocator);
            skillsTextbox.SendKeys(skills);

            //choose language level from dropdown
            skillLevelOption = driver.FindElement(skillLevelOptionLocator);
            skillLevelOption.Click();

            //click on add button
            IWebElement addSkillButton = driver.FindElement(By.CssSelector("input[class='ui teal button ']"));
            addSkillButton.Click();

            WaitUtils.WaitToBeVisible(driver, "xpath", "//td[text()='Multitasking']", 7);
            //check if language is added
            IWebElement newSkillAdded = driver.FindElement(By.XPath("//td[text()='Multitasking']"));
            Assert.That(newSkillAdded.Text == "Multitasking", "New Skill not added");
        }
        public void EditSkill(IWebDriver driver)
        {
            WaitUtils.WaitToBeClickable(driver, "xpath", "//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[3]/div/div[2]/div/table/tbody/tr/td[3]/span[1]/i", 5);
            IWebElement editNewLangButton = driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[3]/div/div[2]/div/table/tbody/tr/td[3]/span[1]/i"));
            editNewLangButton.Click();
            Console.WriteLine("edit btn clicked");
            //Enter skill 
            editSkillTextbox = driver.FindElement(editSkillTextboxLocator);
            editSkillTextbox.Clear();
            editSkillTextbox.SendKeys("Multitasker");
            //Enter skill level 
            editSkillLevel = driver.FindElement(editSkillLevelLocator);
            editSkillLevel.Click();
            //click on update button
            IWebElement updateSkillButton = driver.FindElement(By.XPath("//input[@value='Update']"));
            updateSkillButton.Click();
            Console.WriteLine("update button clicked");
            WaitUtils.WaitToBeVisible(driver, "xpath", "//td[text()='Multitasker']", 10);

            IWebElement editSkillAdded = driver.FindElement(By.XPath("//td[text()='Multitasker']"));
            Assert.That(editSkillAdded.Text == "Multitasker", "New Skill not updated");
        }
        public void RemoveSkill(IWebDriver driver)
        {
            IWebElement deleteSkillButton = driver.FindElement(By.CssSelector("i[class='remove icon']"));
            deleteSkillButton.Click();
            WaitUtils.WaitToBeVisible(driver, "cssselector", "div[class='ns-box-inner']", 10);
            IWebElement deleteSkillAdded = driver.FindElement(By.CssSelector("div[class='ns-box-inner']"));
            if (deleteSkillAdded.Text == "Multitasking")
            {
                Console.WriteLine("Skill not deleted");
            }
            else
            {
                Console.WriteLine("Skill deleted");
            }
            Assert.That(deleteSkillAdded.Text != "Multitasking", "New Skill not updated");
        }
    }
}
