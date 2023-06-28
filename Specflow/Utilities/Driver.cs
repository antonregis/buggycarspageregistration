using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Firefox;
using WebDriverManager.DriverConfigs.Impl;


namespace BuggyCars.Utilities
{
    public class Driver
    {
        // Initialize the browser
        public static IWebDriver driver = null!;


        public static void InitializeBrowser(int browserType)
        {
            // Initializing browser
            switch (browserType)
            {
                case 1:
                    new WebDriverManager.DriverManager().SetUpDriver(new ChromeConfig());
                    driver = new ChromeDriver();
                    break;
                case 2:
                    new WebDriverManager.DriverManager().SetUpDriver(new ChromeConfig());
                    var chromeOptions = new ChromeOptions();
                    chromeOptions.AddArgument("headless");
                    driver = new ChromeDriver(chromeOptions);
                    break;
                case 3:
                    new WebDriverManager.DriverManager().SetUpDriver(new FirefoxConfig());
                    driver = new FirefoxDriver();
                    break;
                case 4:
                    new WebDriverManager.DriverManager().SetUpDriver(new EdgeConfig());
                    driver = new EdgeDriver();
                    break;
                default:
                    Console.WriteLine("Browser Type Options:");
                    Console.WriteLine("1 - Chrome");
                    Console.WriteLine("2 - Headless Chrome");
                    Console.WriteLine("3 - Firefox");
                    Console.WriteLine("4 - Edge");
                    throw new ArgumentException(browserType + " is Invalid Browser Type!");
            }

            // Implicit wait global time declaration
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);

            // Maximize browser window
            driver.Manage().Window.Maximize();           
        }
    }
}