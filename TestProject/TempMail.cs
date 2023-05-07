using OpenQA.Selenium.Interactions;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestProject.BaseLayer;
using System.Linq;
using System.Threading;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using TestProject.POM;
using OpenQA.Selenium.Support.UI;

namespace TestProject
{
    public class TempMail : BaseClass
    {
        public TempMail(IWebDriver driver) : base(driver)
        {
            this.driver = driver;
        }
        public void VerifyMail()
        {
   
        }

        public string GetTempEmail()
        {
            //This is Temporary Email Generator Website Where we can Verify our Verification Link
            driver.Navigate().GoToUrl("https://temp-mail.org/");
            Thread.Sleep(8000);
            TakeScreenshot(driver, "Go to Temp Mail Website.png");
            Assert.True(TempEmailRefresh_Button.Displayed);
            string tempEmail = TempEmail_Input.GetAttribute("value");
            //Console.WriteLine("Temp Email = " + tempEmail);
            if(tempEmail == "") Assert.Fail("Can't Get Email");
            return tempEmail;
        }


        public IWebElement TempEmail_Input => driver.FindElement(By.Id("mail"));
        public IWebElement TempEmailRefresh_Button=> driver.FindElement(By.Id("click-to-refresh"));
        public IWebElement ReceivedEmailTitle => driver.FindElement(By.XPath("//*[@class='inboxSubject subject-title']//*[contains(text(),'SVARBU')]"));
        public IWebElement x => driver.FindElement(By.XPath("(//*[@class='col-md-auto justify-content-center']//span)[2]"));

    }
}
