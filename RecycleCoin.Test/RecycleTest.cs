using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace RecycleCoin.Test
{
    public class RecycleTest
    {
        IWebDriver driver = new ChromeDriver(@"../../../chromedriver.exe");

        [Fact]
        public void OpenWebsite()
        {
            driver.Navigate().GoToUrl("http://localhost:5007");
            driver.Quit();
        }

        [Fact]
        public void Login()
        {
            driver.Navigate().GoToUrl("http://localhost:5007");

            driver.FindElement(By.XPath("/html/body/nav/div/div[2]/ul/a/span")).Click();

            driver.FindElement(By.XPath("/html/body/section/div/div/div/div/div/form/div/div[1]/input")).SendKeys("hms45267@gmail.com");
            driver.FindElement(By.XPath("/html/body/section/div/div/div/div/div/form/div/div[2]/input")).SendKeys("password");
            driver.FindElement(By.XPath("/html/body/section/div/div/div/div/div/form/div/button")).Click();
            driver.Quit();
        }

        [Fact]
        public void Register()
        {
            driver.Navigate().GoToUrl("http://localhost:5007");

            driver.FindElement(By.XPath("/html/body/section[1]/div/div/div[1]/div[2]/a")).Click();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(1);
            driver.FindElement(By.XPath("/html/body/section/div/div/div/div/div/form/div/div[1]/input")).SendKeys("emir_baran");
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(1);
            driver.FindElement(By.XPath("/html/body/section/div/div/div/div/div/form/div/div[2]/input")).SendKeys("emir_baran@hotmail.com");
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(1);
            driver.FindElement(By.XPath("/html/body/section/div/div/div/div/div/form/div/div[3]/input")).SendKeys("emir2001");
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(1);
            driver.FindElement(By.XPath("/html/body/section/div/div/div/div/div/form/div/div[4]/input")).SendKeys("emir2001");
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(1);
            driver.FindElement(By.XPath("/html/body/section/div/div/div/div/div/form/div/button")).Click();
            driver.Quit();
        }

        [Fact]
        public void AddQuestion()
        {
            driver.Navigate().GoToUrl("http://localhost:5007");

            driver.FindElement(By.XPath("/html/body/nav/div/div[2]/ul/a/span")).Click();

            driver.FindElement(By.XPath("/html/body/section/div/div/div/div/div/form/div/div[1]/input")).SendKeys("hms45267@gmail.com");
            driver.FindElement(By.XPath("/html/body/section/div/div/div/div/div/form/div/div[2]/input")).SendKeys("password");
            driver.FindElement(By.XPath("/html/body/section/div/div/div/div/div/form/div/button")).Click();

            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(1);
            driver.FindElement(By.XPath("/html/body/nav/div/div[2]/ul/li[3]/a")).Click();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(1);
            driver.FindElement(By.XPath("/html/body/section/div/div/div/div/div[1]/form/button")).Click();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(1);
            driver.FindElement(By.XPath("/html/body/section/div/div/div/div/div/div/form/input[1]")).SendKeys("What recycling means?");
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(1);
            driver.FindElement(By.XPath("/html/body/section/div/div/div/div/div/div/form/div[1]/div[2]/div/p")).SendKeys("Recycling is the process of collecting and processing materials that would otherwise be thrown away as trash and turning them into new products. Recycling can benefit your community and the environment.");
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(1);
            driver.FindElement(By.XPath("/html/body/section/div/div/div/div/div/div/form/div[2]/button")).Click();
            driver.Quit();
        }

    }
}