using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;

namespace TesteSelenium
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Testando o uso de Selenium..");

            var chromeOptions = new ChromeOptions();
            chromeOptions.AddArgument("--headless");
            chromeOptions.AddArgument("--log-level=3");
            //chromeOptions.AddArgument("--disable-logging");
            //chromeOptions.UnhandledPromptBehavior = UnhandledPromptBehavior.Dismiss;

            var service = ChromeDriverService.CreateDefaultService();
            service.SuppressInitialDiagnosticInformation = true;

            chromeOptions.SetLoggingPreference(LogType.Browser, LogLevel.Off);
            chromeOptions.SetLoggingPreference(LogType.Driver, LogLevel.Off);

            /*chromeOptions.AddUserProfilePreference("webdriver.log.client.ignore", true);
            chromeOptions.AddUserProfilePreference("webdriver.log.server.ignore", true);
            chromeOptions.AddUserProfilePreference("webdriver.log.profiler.ignore", true);*/
            
            ChromeDriver driver;

            if (Environment.OSVersion.VersionString.ToLower().Contains("windows"))
                driver = new ChromeDriver("D:\\Selenium\\Chrome\\", chromeOptions);
            else
                driver = new ChromeDriver(service, chromeOptions);


            driver.Manage().Timeouts().PageLoad = TimeSpan.FromSeconds(30);
            //driver.Manage().Timeouts().AsynchronousJavaScript = TimeSpan.FromSeconds(30);
            //driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(60);

            var siteTestes = Environment.GetEnvironmentVariable("SiteTestes");
            driver.Navigate().GoToUrl("https://anp-imagemnasa.azurewebsites.net/");
            //driver.Navigate().GoToUrl("https://github.com");

            //System.Threading.Thread.Sleep(3000);

            Console.WriteLine($"Resultado: {driver.Title}");

            //Close the browser
            driver.Quit();
        }
    }
}
