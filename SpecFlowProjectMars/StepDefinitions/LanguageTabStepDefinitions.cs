using SpecFlowProjectMars.Pages;
using SpecFlowProjectMars.Utilities;
using System;
using System.Reflection.Emit;
using TechTalk.SpecFlow;

namespace SpecFlowProjectMars.StepDefinitions
{
    [Binding]
    public class LanguageTabStepDefinitions:CommonDriver
    {
        LoginPage loginPageObj = new LoginPage();
        ProfileHomePage profilePageObj = new ProfileHomePage();
        LanguagePage languagePageObj = new LanguagePage();

        [Given(@"user logs into Mars Portal")]
        public void GivenUserLogsIntoMarsPortal()
        {
            loginPageObj.LoginActions(driver, "geothy@gmail.com", "7geothy*");
            profilePageObj.VerifyLoggedInUser(driver);
        }

        [Given(@"navigates to Languages tab in Profile Page")]
        public void GivenNavigatesToLanguagesTabInProfilePage()
        {
            profilePageObj.NavigateToLanguagePanel(driver);
        }

        [When(@"user enters Language ""([^""]*)"" and Language Level ""([^""]*)""")]
        public void WhenUserEntersLanguageAndLanguageLevel(string language, string level)
        {
            languagePageObj.ClearData();
            languagePageObj.AddLanguage(driver, language, level);
           //languagePageObj.AddLanguage(driver, language, level);
        }

        [Then(@"the language ""([^""]*)"" should be added to Languages tab in Profile Page")]
        public void ThenTheLanguageShouldBeAddedToLanguagesTabInProfilePage(string language)
        {
            languagePageObj.AddLanguageAssertion(driver, language);
        }

        [When(@"user edits Language and Language Level")]
        public void WhenUserEditsLanguageAndLanguageLevel()
        {
            languagePageObj.EditLanguage(driver);
        }

        [Then(@"the language should be edited into Languages tab in Profile Page")]
        public void ThenTheLanguageShouldBeEditedIntoLanguagesTabInProfilePage()
        {
            languagePageObj.EditLanguageAssert(driver);
        }

        [When(@"user deletes the Language")]
        public void WhenUserDeletesTheLanguage()
        {
            languagePageObj.RemoveLanguage(driver);
        }

        [Then(@"the language should be deleted from Languages tab in Profile Page")]
        public void ThenTheLanguageShouldBeDeletedFromLanguagesTabInProfilePage()
        {
            languagePageObj.RemoveLanguageAssert(driver);
        }
    }
}
