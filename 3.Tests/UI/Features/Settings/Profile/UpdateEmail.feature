Feature: Email update
    As a logged in user, the user should be able to update his email from his profile settings.

    Background:
        Given the user is logged in
            And the user clicks on the Settings option on the Nav Bar
        When the user clicks on the Email input

    @Acceptance
    Scenario: Update email succesfully
        And inputs a new valid email "testjg@email.com"
        And clicks on the OK button
        Then an alert should appear with the message "Email Address has changed, please relogin." 
        When the user clicks on the accept button
            And is logged out
            And clicks on Login
            And inputs the new email "testjg@email.com"
            And inputs the password
            And clicks on Login button
        Then the user should be logged in

    @Negative
    Scenario: Fail to update email with empty input
        And inputs an email ""
        And clicks on the OK button
        Then an alert should appear with the message "Incorrect Email Address" 
            And an accept button is displayed

    @Negative
    Scenario: Fail to update email with an existing email
        And inputs an existing email "newemail@email.com"
        And clicks on the OK button
        Then an alert should appear with the message "Email Address already exists" 
            And an accept button is displayed
