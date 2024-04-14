using Mars2024.Utilities;
using OpenQA.Selenium;

namespace Mars2024.Pages
{
    public class LoginPage
    {
        private readonly By signInButtonLocator = By.XPath("//a[text()='Sign In']");
        IWebElement signInButton;
        private readonly By usernameTextboxLocator = By.XPath("//input[@name='email']");
        IWebElement usernameTextbox;
        private readonly By passwordTextboxLocator = By.XPath("//input[@name='password']");
        IWebElement passwordTextbox;
        private readonly By loginButtonLocator = By.XPath("//button[text()='Login']");
        IWebElement logInButton;
        public void LoginActions(IWebDriver driver,string username,string password)
        {
            driver.Manage().Window.Maximize();
            driver.Manage().Timeouts().ImplicitWait=TimeSpan.FromSeconds(5);
            //Launch Turnup Portal & Navigate to Login Page

            string baseURL = " http://localhost:5000/";
            driver.Navigate().GoToUrl(baseURL);
            
            //Identify Signin Button & Click on Signin Button
            signInButton = driver.FindElement(signInButtonLocator);
            signInButton.Click();
            WaitUtils.WaitToBeVisible(driver, "XPath", "//input[@name='email']", 5);

            //Identify Username textbox & enter valid username
            usernameTextbox = driver.FindElement(usernameTextboxLocator);
            usernameTextbox.SendKeys(username);


            //Identify Password textbox & enter valid password
            passwordTextbox = driver.FindElement(passwordTextboxLocator);
            passwordTextbox.SendKeys(password);

            //Identify Login Button & Click on Login Button
            logInButton = driver.FindElement(loginButtonLocator);
            logInButton.Click();
            

        }
    }
}
