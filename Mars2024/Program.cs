
using Mars2024.Pages;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;


public class Program
{
    private static void Main(string[] args)
    {
        //Open browser
        IWebDriver driver = new ChromeDriver();
        LoginPage loginPageObj = new LoginPage();
        ProfileHomePage profilePageObj = new ProfileHomePage();
        LanguagePage languagePageObj = new LanguagePage();
        SkillsPage skillPageObj = new SkillsPage();

        loginPageObj.LoginActions(driver, "geothy@gmail.com", "7geothy*");
        profilePageObj.VerifyLoggedInUser(driver);

        profilePageObj.NavigateToLanguagePanel(driver);
        languagePageObj.AddLanguage(driver, "English");
        languagePageObj.EditLanguage(driver);
        languagePageObj.RemoveLanguage(driver);
        
        profilePageObj.NavigateToSkillsPanel(driver);
        skillPageObj.AddSkills(driver,"Multitasking");
        skillPageObj.EditSkill(driver);
        skillPageObj.RemoveSkill(driver);
        driver.Quit();
        





    }
}