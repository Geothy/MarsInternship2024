using SpecFlowProjectMars.Pages;
using SpecFlowProjectMars.Utilities;
using System;
using TechTalk.SpecFlow;

namespace SpecFlowProjectMars.StepDefinitions
{
    [Binding]
    public class SkillsTabStepDefinitions : CommonDriver
    {
        LoginPage loginPageObj = new LoginPage();
        ProfileHomePage profilePageObj = new ProfileHomePage();
        SkillsPage skillPageObj = new SkillsPage();

        [Given(@"User logs into Mars Portal")]
        public void GivenUserLogsIntoMarsPortal()
        {
            loginPageObj.LoginActions(driver, "geothy@gmail.com", "7geothy*");
            profilePageObj.VerifyLoggedInUser(driver);
        }

        [Given(@"navigates to Skills tab in Profile Page")]
        public void GivenNavigatesToSkillsTabInProfilePage()
        {
            profilePageObj.NavigateToSkillsPanel(driver);
        }

        [When(@"user enters Skill ""([^""]*)"" and Skill Level ""([^""]*)""")]
        public void WhenUserEntersSkillAndSkillLevel(string skill, string skilllevel)
        {
            skillPageObj.ClearData();
            skillPageObj.AddSkills(driver, skill, skilllevel);
        }

        [Then(@"the Skill ""([^""]*)"" should be added to Skills tab in Profile Page")]
        public void ThenTheSkillShouldBeAddedToSkillsTabInProfilePage(string skill)
        {
            skillPageObj.AddSkillsAssert(driver, skill);
        }

        [When(@"user edits Skill and Skill Level")]
        public void WhenUserEditsSkillAndSkillLevel()
        {
            skillPageObj.EditSkill(driver);
        }

        [Then(@"the Skill should be updated to Skills tab in Profile Page")]
        public void ThenTheSkillShouldBeUpdatedToSkillsTabInProfilePage()
        {
            skillPageObj.EditSkillAssert(driver);
        }

        [When(@"user deletes Skill")]
        public void WhenUserDeletesSkill()
        {
            skillPageObj.RemoveSkill(driver);
        }

        [Then(@"the Skill should be deleted from Skills tab in Profile Page")]
        public void ThenTheSkillShouldBeDeletedFromSkillsTabInProfilePage()
        {
            skillPageObj.RemoveSkillAssert(driver);
        }
    }
}
