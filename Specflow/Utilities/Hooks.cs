using TechTalk.SpecFlow;


namespace BuggyCars.Utilities
{
    [Binding]
    public class Hooks : Driver
    {

        [BeforeScenario]
        public void BeforeScenario()
        {
            // Launch the browser
            InitializeBrowser(1);
        }

        [AfterScenario]
        public void TearDown()
        {
            driver.Quit();
        }

    }
}