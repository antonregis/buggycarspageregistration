Feature: Registration

As a visitor, I want to register on the website so that I can access the platform.


Background: 
    Given I am on the registration page as a visitor    
    When I enter valid registration details


Scenario: A visitor can register with valid password    
    When I enter password that meets the minimum requirements
    And I submit the registration form
    Then a success message is displayed


Scenario Outline: A visitor cannot register with invalid password
    When I enter '<password>' that does not meet the minimum requirements
    And I submit the registration form
    Then an error message is displayed stating the password '<requirements>'
    
    Examples: 
    | password | requirements                                                                  |
    | password | Password did not conform with policy: Password must have uppercase characters |
    | PASSWORD | Password did not conform with policy: Password must have lowercase characters |
    | Passw0rd | Password did not conform with policy: Password must have symbol characters    |
    | Passw0r  | Password did not conform with policy: Password must have 8 characters minimum |


Scenario: A visitor can only register once
    When I enter password that meets the minimum requirements    
    And I submit the registration form
    Then a success message is displayed
    When I attempt to register again with the same details and password
    Then an error message is displayed stating that I am already registered