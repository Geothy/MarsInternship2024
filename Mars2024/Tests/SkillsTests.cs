using Mars2024.Pages;
using Mars2024.Utilities;
using NUnit.Framework;
using OpenQA.Selenium.Chrome;

namespace Mars2024.Tests
{
    [TestFixture]
    public class SkillsTests : CommonDriver
    {

        LoginPage loginPageObj = new LoginPage();
        ProfileHomePage profilePageObj = new ProfileHomePage();
        SkillsPage skillPageObj = new SkillsPage();

        [SetUp]
        public void SetupSkills()
        {
            driver = new ChromeDriver();
            loginPageObj.LoginActions(driver, "geothy@gmail.com", "7geothy*");
            profilePageObj.VerifyLoggedInUser(driver);
            profilePageObj.NavigateToSkillsPanel(driver);

        }
        [Test, Order(1), Description("This test adds a new Skill ")]
        public void TestAddSkill()
        {
            skillPageObj.AddSkills(driver, "Multitasking");
        }
        [Test, Order(2), Description("This test edits the Skill ")]
        public void TestEditSkill()
        {
            skillPageObj.EditSkill(driver);
        }
        [Test, Order(3), Description("This test deletes the Skill ")]
        public void TestRemoveSkill()
        {
            skillPageObj.RemoveSkill(driver);
        }
        [TearDown]
        public void CloseTestRun()
        {
            driver.Quit();
        }
    }
}
