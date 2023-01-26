using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace homework
{
    class Program
    {
        static void Main(string[] args)
        {
            IWebDriver driver = new ChromeDriver();

            


            driver.Navigate().GoToUrl("https://www.saucedemo.com/");


            driver.FindElement(By.Id("user-name")).SendKeys("standard_user");
            driver.FindElement(By.Id("password")).SendKeys("secret_sauce");
            driver.FindElement(By.Id("login-button")).Click();


            driver.FindElement(By.Id("add-to-cart-sauce-labs-backpack")).Click();
            driver.FindElement(By.Id("add-to-cart-sauce-labs-bike-light")).Click();
            driver.FindElement(By.Id("add-to-cart-sauce-labs-bolt-t-shirt")).Click();


            driver.FindElement(By.CssSelector(".shopping_cart_link")).Click();
            driver.FindElement(By.Id("checkout")).Click();


            driver.FindElement(By.Id("first-name")).SendKeys("Hubert");
            driver.FindElement(By.Id("last-name")).SendKeys("Student");
            driver.FindElement(By.Id("postal-code")).SendKeys("76-1234");
            driver.FindElement(By.Id("continue")).Click();


            var totalprice = driver.FindElement(By.CssSelector(".summary_total_label")).Text;
            Assert.IsTrue(totalprice == "Total: $60.45"); //nie wiem jak pobrac samą liczbe a chcaiłem pobrac wartosci przdmoitów i je dodac i porównac do wartosci totalnej


            driver.FindElement(By.Id("finish")).Click();


            var message = driver.FindElement(By.CssSelector(".complete-header")).Text;
            Assert.AreEqual(message, "THANK YOU FOR YOUR ORDER");


        }
    }
}
