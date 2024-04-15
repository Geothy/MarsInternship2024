using Mars2024.Pages;
using Mars2024.Utilities;
using NUnit.Framework;
using OpenQA.Selenium.Chrome;

namespace Mars2024.Tests
{
    [TestFixture]
    public class LanguageTests : CommonDriver
    {

        LoginPage loginPageObj = new LoginPage();
        ProfileHomePage profilePageObj = new ProfileHomePage();
        LanguagePage languagePageObj = new LanguagePage();
        [SetUp]
        public void SetupLanguage()
        {
            driver = new ChromeDriver();
            loginPageObj.LoginActions(driver, "geothy@gmail.com", "7geothy*");
            profilePageObj.VerifyLoggedInUser(driver);
            profilePageObj.NavigateToLanguagePanel(driver);
        }
        [Test, Order(1), Description("This test adds a new language ")]
        public void TestAddLanguage()
        {
            languagePageObj.AddLanguage(driver, "English");
        }
        [Test, Order(2), Description("This test edits the language ")]
        public void TestEditLanguage()
        {
            languagePageObj.EditLanguage(driver);
        }
        [Test, Order(3), Description("This test deletes the language ")]
        public void TestRemoveLanguage()
        {
            languagePageObj.RemoveLanguage(driver);
        }
        [TearDown]
        public void CloseTestRun()
        {
            driver.Quit();
        }
    }
}
