Feature: Password update
    As a logged in user, the user should be able to update his password from his profile settings.

    Background:
        Given the user is logged in
            And the user clicks on the Settings option on the Nav Bar
        When the user clicks on the Old Password input
            And inputs his password

    @Acceptance
    Scenario: Update password succesfully
        And clicks on the New Password input
        And inputs a new valid password "newpassword"
        And clicks on the OK button
        Then the password is updated and the settings view is closed

    @Negative
    Scenario: Fail to update password with empty input
        And clicks on the OK button
        Then an alert should appear with the message "Invalid Password" and a button to accept it

