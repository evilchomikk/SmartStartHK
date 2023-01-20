using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;


namespace KursHomework1
{
    class Program
    {
        static void Main(string[] args)
        { 
            By usernerm = By.Id("user-name");
            //By password = By.CssSelector("input[placeholder=Password]");
            By password = By.Id("password");
            By loginbtn = By.Id("login-button");
            By backpack = By.Id("item_4_img_link");
            By addtocart = By.CssSelector("button[name=add-to-cart-sauce-labs-backpack]");
            By cart = By.CssSelector(".shopping_cart_link");

            IWebDriver driver = new ChromeDriver();
            driver.Navigate().GoToUrl(@"https://www.saucedemo.com/");
            driver.Manage().Window.Maximize();
    
            driver.FindElement(usernerm).SendKeys("standard_user");
            driver.FindElement(password).SendKeys("secret_sauce");
            driver.FindElement(loginbtn).Click();
            driver.FindElement(backpack).Click();
            driver.FindElement(addtocart).Click();
            driver.FindElement(cart).Click();


            var name = driver.FindElement(By.CssSelector(".inventory_item_name")).Text;
            Assert.IsInstanceOfType<string>(name);

            var price = driver.FindElement(By.CssSelector(".inventory_item_price")).Text;//".nazwaklasy" class=nazwa
            Assert.AreEqual(price, "$29.99");

            var quantity = driver.FindElement(By.CssSelector(".cart_quantity")).Text;
            Assert.IsTrue(quantity == "1");

            Console.WriteLine($"item name{name}");
            Console.WriteLine($"item price{price}");
            Console.WriteLine($"item quantity:{quantity}");

            Console.ReadLine();
            driver.Quit(); 






        }
    }
}