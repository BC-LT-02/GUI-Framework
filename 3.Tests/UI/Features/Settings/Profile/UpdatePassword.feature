Feature: Password update
    As a logged in user, the user should be able to update his password from his profile settings.

    Background:
        Given the user is logged in
            And the user clicks on the Settings option on the Nav Bar
        When the user inputs his password on the Old Password input

    @Acceptance @recover.password
    Scenario: Update password succesfully
        And inputs a new valid password "newpassword" on the New Password input
        And clicks on the OK button
        Then the password is updated closing the settings view

    # @Negative
    # Scenario: Fail to update password with empty input
    #     And clicks on the OK button
    #     Then an alert should appear with the message "Invalid Password"
    #         And an accept button is displayed

