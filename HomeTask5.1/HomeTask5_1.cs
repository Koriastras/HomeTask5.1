using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;


namespace HomeTask5._1
{
    [TestFixture]
    public class HomeTask5_1
    {

        IWebDriver driver;

        [OneTimeSetUp]

        public void BeforeTest()
        {

            driver = new ChromeDriver();
            driver.Manage().Window.Maximize();

        }

        [OneTimeTearDown]

        public void AfterTest()
        {
            driver.Quit();
        }


        [Test]
        public void LoginProcess()
        {
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(5));
            string basePageUrl = "https://www.demoblaze.com/index.html";
            driver.Navigate().GoToUrl(basePageUrl);

            wait.Until(x => x.FindElement(By.Id("nava")).Displayed);

            IWebElement loginButton = driver.FindElement(By.Id("login2"));
            IWebElement loginButtonXPath = driver.FindElement(By.XPath("//a[@data-target = '#logInModal']"));
            IWebElement loginButtonCss = driver.FindElement(By.CssSelector("a[data-target = '#logInModal']"));
            loginButton.Click();

            // wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("//input[@id = 'loginusername']")));

            wait.Until(x => x.FindElement(By.XPath("//input[@id = 'loginusername']")).Displayed);

            IWebElement usernameBox = driver.FindElement(By.Id("loginusername"));
            IWebElement usernameBoxXPath = driver.FindElement(By.XPath("//input[@id = 'loginusername']"));
            IWebElement usernameBoxCss = driver.FindElement(By.CssSelector("input[id^='loginuser']"));
            usernameBox.Click();
            usernameBox.Clear();
            usernameBoxXPath.SendKeys("KoriAstras");

            IWebElement passwordBox = driver.FindElement(By.Id("loginpassword"));
            IWebElement passwordBoxXPath = driver.FindElement(By.XPath("//input[@id = 'loginpassword' and @type = 'password']"));
            IWebElement passwordBoxCss = driver.FindElement(By.CssSelector("input[type = 'password'][id = 'loginpassword']"));
            passwordBox.Click();
            passwordBox.Clear();
            passwordBoxCss.SendKeys("Kori123!");

            IWebElement submitBoxXPath = driver.FindElement(By.XPath("//button[@onclick = 'logIn()']"));
            IWebElement submitBoxCss = driver.FindElement(By.CssSelector("button[onclick = 'logIn()']"));


            submitBoxXPath.Click();

            wait.Until(x => x.FindElement(By.Id("logout2")).Displayed);
            Assert.True(driver.FindElement(By.XPath("//a[@onclick = 'logOut()']")).Displayed, "Logout button is not displayed");

            string nameOfUser = driver.FindElement(By.CssSelector("#nameofuser")).Text;
            Assert.True(driver.FindElement(By.XPath("//*[@id = 'nameofuser']")).Displayed, "Name of user is not displayed");

            Assert.AreEqual(nameOfUser, "Welcome KoriAstras", "Username is different");
        }

    }
}