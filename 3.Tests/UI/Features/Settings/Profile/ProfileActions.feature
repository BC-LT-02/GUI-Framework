Feature: Settings actions operations
    As a logged in user, the user should be able to update his email from his profile settings.

    Background:
        Given the user is logged in

    @Smoke @Acceptance @recover.email
    Scenario: Update email succesfully
        When the user clicks on 'Settings' at 'Home Page'
        And types "testjg@email.com" on 'Email' at 'Profile Page'
        And clicks on 'Ok'
        Then an alert should appear with the message "Email Address has changed, please relogin."
        When the user accepts the alert
        And clicks on 'Login' at 'Login Page'
        And introduces his credentials
        And clicks on 'Confirm Login'
        Then the 'Logout' should be displayed at 'Home Page'

    @Smoke @Regression @restore.default.fullname
    Scenario: Update full name succesfully
        When the user clicks on 'Settings' at 'Home Page'
        And types "New Name" on 'FullName' at 'Profile Page'
        And clicks on 'Ok'
        Then the 'NonDisplayedClose' should not be displayed
        When the user clicks on 'Settings' at 'Home Page'
        Then the 'FullName' value is updated with 'New Name' at 'Profile Page'

    @Smoke @Acceptance @recover.password
    Scenario: Update password succesfully
        When the user clicks on 'Settings' at 'Home Page'
        And types "Password Credential" on 'Old Password' at 'Profile Page'
        And types "New Password" on 'New Password'
        And clicks on 'Ok'
        Then the 'NonDisplayedClose' should not be displayed

    @Acceptance @restore.default.timezone
    Scenario: Update time zone succesfully
        When the user clicks on 'Settings' at 'Home Page'
        And clicks on 'Time Zone' at 'Profile Page'
        And clicks on 'Hawaiian Time'
        And clicks on 'Ok'
        Then the 'NonDisplayedClose' should not be displayed
        When the user clicks on 'Settings' at 'Home Page'
        And the 'Hawaiian Time' is selected at 'Profile Page'

    @Smoke @Regression
    Scenario: View profile settings succesfully
        When the user clicks on 'Settings' at 'Home Page'
        Then the 'Profile Settings' should be displayed at 'Profile Page'
        And the 'FullName' should be displayed
        And the 'Email' should be displayed
        And the 'Old Password' should be displayed
        And the 'New Password' should be displayed

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
