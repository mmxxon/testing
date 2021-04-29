using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using NUnit.Framework;

namespace testing
{
    class Program
    {
        static void Main(string[] args)
        {
            using (IWebDriver driver = new ChromeDriver())
            {
                // Task 1
                WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
                driver.Navigate().GoToUrl("https://www.google.com/ncr");
                driver.FindElement(By.Name("q")).SendKeys("Розклад КПІ" + Keys.Enter);
                wait.Until(webDriver => webDriver.FindElement(By.CssSelector("h3")).Displayed);
                driver.FindElement(By.CssSelector("h3")).Click();
                wait.Until(webDriver => webDriver.FindElement(By.Name(@"ctl00$MainContent$ctl00$txtboxGroup")));
                driver.FindElement(By.Name(@"ctl00$MainContent$ctl00$txtboxGroup")).SendKeys("КП-92");
                wait.Until(webDriver => webDriver.FindElement(By.Name(@"ctl00$MainContent$ctl00$btnShowSchedule")));
                driver.FindElement(By.Name(@"ctl00$MainContent$ctl00$btnShowSchedule")).Click();
                wait.Until(webDriver => webDriver.FindElement(By.XPath("//*[@id=\"ctl00_MainContent_FirstScheduleTable\"]/tbody/tr[2]/td[4]/span/a")));
                IWebElement elem = driver.FindElement(By.XPath("//*[@id=\"ctl00_MainContent_FirstScheduleTable\"]/tbody/tr[2]/td[4]/span/a"));
                Assert.AreEqual(elem.Text, "Компоненти програмної інженерії 2. Якість та тестування програмного забезпечення");

                // Task 2
                driver.Navigate().GoToUrl("https://www.google.com/ncr");
                driver.FindElement(By.Name("q")).SendKeys("Епіцентр" + Keys.Enter);
                wait.Until(webDriver => webDriver.FindElement(By.CssSelector("h3")).Displayed);
                driver.FindElement(By.CssSelector("h3")).Click();
                wait.Until(webDriver => webDriver.FindElement(By.XPath("/html/body/footer/div[2]/div/div[2]/div/nav/a[3]")));
                driver.FindElement(By.XPath("/html/body/footer/div[2]/div/div[2]/div/nav/a[3]")).Click();
                wait.Until(webDriver => webDriver.FindElement(By.XPath("/html/body/main/div[2]/div/section/h3")));
                IWebElement elem2 = driver.FindElement(By.XPath("/html/body/main/div[2]/div/section/h3"));
                Assert.AreEqual(elem2.Text, "Контакт-центр працює для Вас щоденно з 07:30 до 22:30.");

                // Task 3
                driver.Navigate().GoToUrl("https://www.google.com/ncr");
                driver.FindElement(By.Name("q")).SendKeys("доллар до гривні" + Keys.Enter);
                IWebElement elem3 = driver.FindElement(By.XPath("/html/body/div[7]/div/div[9]/div[1]/div/div[2]/div[2]/div/div/div[1]/div/div/div/div/div[1]/div/div[1]/div[1]/div[2]/span[1]"));
                Assert.Less(Double.Parse(elem3.Text), 50);
            }
        }
    }
}
