using BuggyCars.Utilities;
using OpenQA.Selenium;


namespace BuggyCars.Pages
{
    public class RegistrationPage : Driver
    {
        private static IWebElement loginNameField => driver.FindElement(By.CssSelector("#username"));
        private static IWebElement firstNameField => driver.FindElement(By.CssSelector("#firstName"));
        private static IWebElement lastNameField => driver.FindElement(By.CssSelector("#lastName"));
        private static IWebElement passwordField => driver.FindElement(By.CssSelector("#password"));
        private static IWebElement confirmPasswordField => driver.FindElement(By.CssSelector("#confirmPassword"));
        private static IWebElement registerBtn => driver.FindElement(By.XPath("//button[normalize-space()='Register']"));
        private static IWebElement alertMessageBox => driver.FindElement(By.XPath("/html/body/my-app/div/main/my-register/div/div/form/div[6]"));

        private string? username;


        public void EnterValidRegistrationDetails()
        {
            username = GenerateUsername(); // Generate unique username

            loginNameField.SendKeys(username);
            firstNameField.SendKeys("Anthony");
            lastNameField.SendKeys("Regis");
        }

        public void EnterDuplicatedRegistrationDetails()
        {
            loginNameField.SendKeys(username); // Reuse generated username from EnterValidRegistrationDetails()
            firstNameField.SendKeys("Anthony");
            lastNameField.SendKeys("Regis");
        }

        public void EnterValidPassword() 
        {
            string password = "Passw0rd_";
            passwordField.SendKeys(password);
            confirmPasswordField.SendKeys(password);
        }

        public void EnterInvalidPassword(string password)
        {
            passwordField.SendKeys(password);
            confirmPasswordField.SendKeys(password);
        }

        public void ClickRegisterButton() 
        { 
            registerBtn.Click();
        }

        public string GetAlertMessageBox()
        {
            return alertMessageBox.Text;
        }

        private static string GenerateUsername() 
        {
            DateTime currentTime = DateTime.UtcNow; // Get the current time in UTC
            DateTime unixEpoch = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);
            TimeSpan timeSinceEpoch = currentTime - unixEpoch;
            long unixTimestamp = (long)timeSinceEpoch.TotalSeconds;
            return "antonregis" + unixTimestamp.ToString();
        }
    }
}
