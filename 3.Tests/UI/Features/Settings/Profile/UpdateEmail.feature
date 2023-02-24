Feature: Email update
    As a logged in user, the user should be able to update his email from his profile settings.

    Background:
        Given the user is logged in

    @Smoke @Acceptance @recover.email
    Scenario: Update email succesfully
        When the user clicks on 'Settings' on 'Home Page'
            And types "testjg@email.com" on 'Email' on 'Profile Page'
            And clicks on 'Ok'
        Then an alert should appear with the message "Email Address has changed, please relogin." 
        When the user accepts the alert
            And clicks on 'Login' on 'Login Page'
            And introduces his credentials
            And clicks on 'Confirm Login'
        Then the 'Logout' should be displayed on 'Home Page'

    # @Negative
    # Scenario: Fail to update email with empty input
    #     And inputs an email ""
    #     And clicks on the OK button
    #     Then an alert should appear with the message "Incorrect Email Address" 
    #         And an accept button is displayed

    # @Negative
    # Scenario: Fail to update email with an existing email
    #     And inputs an existing email "newemail@email.com"
    #     And clicks on the OK button
    #     Then an alert should appear with the message "Email Address already exists" 
    #         And an accept button is displayed

