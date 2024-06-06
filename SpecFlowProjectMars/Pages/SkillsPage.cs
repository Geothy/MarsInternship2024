using NUnit.Framework;
using OpenQA.Selenium;
using SpecFlowProjectMars.Utilities;

namespace SpecFlowProjectMars.Pages
{
    public class SkillsPage : CommonDriver
    {
        IWebElement addNewSkillButton => driver.FindElement(By.CssSelector("div[class='ui teal button']"));
        IWebElement skillsTextbox => driver.FindElement(By.XPath("//input[@type='text'][@placeholder='Add Skill']"));
        IWebElement skillLevelOption => driver.FindElement(By.XPath("//option[text()='Intermediate']"));
        IWebElement addSkillButton => driver.FindElement(By.CssSelector("input[class='ui teal button ']"));
        IWebElement editSkillTextbox => driver.FindElement(By.XPath("//input[@placeholder='Add Skill']"));
        IWebElement editSkillLevel => driver.FindElement(By.XPath("//option[text()='Beginner']"));
        IWebElement newSkillAdded => driver.FindElement(By.XPath("//td[text()='Multitasking']"));
        IWebElement editNewSkillButton => driver.FindElement(By.CssSelector("i[class='outline write icon']"));
        IWebElement updateSkillButton => driver.FindElement(By.XPath("//input[@value='Update']"));
        IWebElement editSkillAdded => driver.FindElement(By.XPath("//td[text()='Multitasker']"));
        IWebElement deleteSkillButton => driver.FindElement(By.CssSelector("i[class='remove icon']"));
        IWebElement deleteSkillAdded => driver.FindElement(By.CssSelector("div[class='ns-box-inner']"));
        private static IWebElement popupmsg => driver.FindElement(By.CssSelector("div[class='ns-box-inner']"));

        public void ClearData()
        {
            try
            {
                var deleteButton = driver.FindElements(By.CssSelector("i[class='remove icon']"));
                foreach (var button in deleteButton)
                {
                    button.Click();
                }
            }
            catch { }

        }
        public void AddSkills(IWebDriver driver, string skills, string skillLevel)
        {
            //Add new language
            addNewSkillButton.Click();
            //Enter language 
            skillsTextbox.SendKeys(skills);
            //choose language level from dropdown
            skillLevelOption.Click();
            //click on add button
            addSkillButton.Click();

        }
        public void AddSkillsAssert(IWebDriver driver, string skills)
        {
            //check if language is added
            //Assert.That(newSkillAdded.Text == "Multitasking", "New Skill not added");
            Thread.Sleep(1000);
            string verifySkill = skills + " has been added to your skills";
            Assert.AreEqual(verifySkill, popupmsg.Text);
        }
        public void EditSkill(IWebDriver driver)
        {
            editNewSkillButton.Click();
            //Enter skill 
            editSkillTextbox.Clear();
            editSkillTextbox.SendKeys("Multitasker");
            //Enter skill level 
            editSkillLevel.Click();
            //click on update button
            updateSkillButton.Click();

        }
        public void EditSkillAssert(IWebDriver driver)
        {
            Assert.That(editSkillAdded.Text == "Multitasker", "New Skill not updated");
        }
        public void RemoveSkill(IWebDriver driver)
        {
            deleteSkillButton.Click();
        }
        public void RemoveSkillAssert(IWebDriver driver)
        {
            Assert.That(deleteSkillAdded.Text != "Multitasking", "New Skill not updated");
        }
    }
}
