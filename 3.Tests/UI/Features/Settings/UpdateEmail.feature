Feature: Email update
    As a logged in user, the user should be able to update his email from his profile settings.

    Background:
        Given the user is logged in
        When the user clicks on 'Settings' at 'Home Page'

    @Smoke @Acceptance @recover.email
    Scenario: Update email succesfully
            And types "testjg@email.com" on 'Email' at 'Profile Page'
            And clicks on 'Ok'
        Then an alert should appear with the message "Email Address has changed, please relogin." 
        When the user accepts the alert
            And clicks on 'Login' at 'Login Page'
            And introduces his credentials
            And clicks on 'Confirm Login'
        Then the 'Logout' should be displayed at 'Home Page'

    @Negative
    Scenario: Fail to update email with empty input
        And types "invalid" on 'Email' at 'Profile Page'
        And clicks on 'Ok'
        Then an alert should appear with the message "Incorrect Email Address" 

    @Negative
    Scenario: Fail to update email with an existing email
        And types "newemail@email.com" on 'Email' at 'Profile Page'
        And clicks on 'Ok'
        Then an alert should appear with the message "Email Address already exists" 
