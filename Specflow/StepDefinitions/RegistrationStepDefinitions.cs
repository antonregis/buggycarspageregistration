using BuggyCars.Pages;
using BuggyCars.Utilities;
using NUnit.Framework;
using TechTalk.SpecFlow;


namespace BuggyCars.StepDefinitions
{
    [Binding]
    public class RegistrationStepDefinitions : Driver
    {        
        RegistrationPage registrationPage = new RegistrationPage();

        
        // Shared Steps

        [Given(@"I am on the registration page as a visitor")]
        public void GivenIAmOnTheRegistrationPageAsAVisitor()
        {
            driver.Navigate().GoToUrl("https://buggy.justtestit.org/register");
        }

        [When(@"I submit the registration form")]
        public void WhenISubmitTheRegistrationForm()
        {
            registrationPage.ClickRegisterButton();
        }

        [When(@"I enter valid registration details")]
        public void WhenIEnterValidRegistrationDetails()
        {
            registrationPage.EnterValidRegistrationDetails();
        }


        // Valid password

        [When(@"I enter password that meets the minimum requirements")]
        public void WhenIEnterPasswordThatMeetsTheMinimumRequirements()
        {
            registrationPage.EnterValidPassword();
        }        

        [Then(@"a success message is displayed")]
        public void ThenASuccessMessageIsDisplayed()
        {
            Assert.That(registrationPage.GetAlertMessageBox, Is.EqualTo("Registration is successful"));
        }


        // Invalid Password

        [When(@"I enter '([^']*)' that does not meet the minimum requirements")]
        public void WhenIEnterThatDoesNotMeetTheMinimumRequirements(string password)
        {
            registrationPage.EnterInvalidPassword(password);
        }

        [Then(@"an error message is displayed stating the password '([^']*)'")]
        public void ThenAnErrorMessageIsDisplayedStatingThePassword(string requirementsMessage)
        {
            Assert.That(registrationPage.GetAlertMessageBox().Contains(requirementsMessage));
        }
        

        // Duplicate Registration

        [When(@"I attempt to register again with the same details and password")]
        public void WhenIAttemptToRegisterAgainWithTheSameDetailsAndPassword()
        {
            registrationPage.EnterDuplicatedRegistrationDetails();
            registrationPage.EnterValidPassword();
            registrationPage.ClickRegisterButton();
        }

        [Then(@"an error message is displayed stating that I am already registered")]
        public void ThenAnErrorMessageIsDisplayedStatingThatIAmAlreadyRegistered()
        {
            Assert.That(registrationPage.GetAlertMessageBox().Contains("User already exists"));
        }
    }
}
