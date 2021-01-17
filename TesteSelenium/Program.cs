﻿using System;
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
            //chromeOptions.UnhandledPromptBehavior = UnhandledPromptBehavior.Dismiss;

            ChromeDriver driver;

            if (Environment.OSVersion.VersionString.ToLower().Contains("windows"))
                driver = new ChromeDriver("D:\\Selenium\\Chrome\\", chromeOptions);
            else
                driver = new ChromeDriver(chromeOptions);

            driver.Manage().Timeouts().PageLoad = TimeSpan.FromSeconds(30);
            //driver.Manage().Timeouts().AsynchronousJavaScript = TimeSpan.FromSeconds(30);
            //driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(60);

            var siteTestes = Environment.GetEnvironmentVariable("SiteTestes");
            driver.Navigate().GoToUrl("https://anp-imagemnasa.azurewebsites.net/");

            System.Threading.Thread.Sleep(3000);

            Console.WriteLine($"Resultado: {driver.Title}");

            //Close the browser
            driver.Quit();
        }
    }
}
