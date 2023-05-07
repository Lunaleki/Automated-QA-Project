using OpenQA.Selenium;
using OpenQA.Selenium.DevTools;
using RestSharp;
using System.Net.Http.Headers;
using TestProject.BaseLayer;
using TestProject.POM;

namespace TestProject
{
    public class Tests : BaseClass
    {

        [Test]
        public void Registration()
        {
            var TempMail = new TempMail(driver);
            var LoginPage = new LoginPage(driver);
            var SignUpPage = new SignUpPage(driver);
            string name, surName, password, randomEmail;
            name = RandomString(8);
            surName = RandomString(10);
            randomEmail = RandomString(8) + "@gmail.com";
            password = RandomString(10);

            //Go to Authorization Page
            var userblock = ExplicitWait(driver, d => LoginPage.UserBlock, 10);
            userblock.Click();
            var registrationButton = ExplicitWait(driver, d => LoginPage.RegistrationButton, 10);
            TakeScreenshot(driver, "Go to Authorization page.png");

            //Go to Registration Page
            registrationButton.Click();
            ExplicitWait(driver, s => SignUpPage.Register_Button, 10);
            TakeScreenshot(driver, "Go to Registration page.png");

            SignUpPage.RegisterNewUser(name, surName, randomEmail, password);
            TakeScreenshot(driver, "Registration Successed.png");
        }

        [Test]
        public void Login()
        {
            string registeredUsername = "tonare2954@syinxun.com";
            string registeredPassword = "1234512345";

            var LoginPage = new LoginPage(driver);

            //Go to Authorization Page
            var userblock = ExplicitWait(driver, d => LoginPage.UserBlock, 10);
            userblock.Click();
            var registrationButton = ExplicitWait(driver, d => LoginPage.RegistrationButton, 10);
            TakeScreenshot(driver, "Go to Authorization page.png");

            //Verify If Login Successed
            LoginPage.VerifyLogin(registeredUsername, registeredPassword);
            TakeScreenshot(driver, "Login Successed.png");
        }

        [Test]
        public void ChangeProfileFirstName()
        {
            string newName = RandomString(8);
            var ProfilePage = new ProfilePage(driver);
            Login();
            ProfilePage.UpdateAccountFirstName(newName);
            TakeScreenshot(driver, "After Update Account First Name.png");
        }

        [Test]
        public void SearchAndVerifyResult()
        {
            var Dashboard = new Dashboard(driver);
            Dashboard.SearchProductAndVerify("Lenovo");
            TakeScreenshot(driver, "After Search Product.png");
        }

        [Test]
        public void AddProductToCartAndVerify()
        {
            var Dashboard = new Dashboard(driver);
            Login();
            Dashboard.SearchProductAndVerify("Lenovo");
            TakeScreenshot(driver, "Before Add Product in Cart.png");
            Dashboard.AddProductToCartAndVerify();
            TakeScreenshot(driver, "After Verify Product Count and Prices in Cart.png");
        }
    }
}