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
        Then an alert should appear with the message "Email Address has changed, please relogin." and a button to accept it
        And when the user clicks on the accept button
        Then the user is logged out and redirected to the Login Page

    @Negative
    Scenario: Fail to update email with empty input
        And leaves the input empty
        And clicks on the OK button
        Then an alert should appear with the message "Incorrect Email Address" and a button to accept it

    @Negative
    Scenario: Fail to update email with an existing email
        And inputs an existing email "newemail@email.com"
        And clicks on the OK button
        Then an alert should appear with the message "Email Address already exists" and a button to accept it

