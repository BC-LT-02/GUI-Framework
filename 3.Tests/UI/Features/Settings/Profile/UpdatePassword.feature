Feature: Password update
    As a logged in user, the user should be able to update his password from his profile settings.

    Background:
        Given the user is logged in

    @Smoke @Acceptance @recover.password
    Scenario: Update password succesfully
        When the user clicks on 'Settings' on 'Home Page'
            And types "Password Credential" on 'Old Password' on 'Profile Page'
            And types "New Password" on 'New Password'
            And clicks on 'Ok'
        Then the 'NonDisplayedClose' should not be displayed

    # @Negative
    # Scenario: Fail to update password with empty input
    #     And clicks on the OK button
    #     Then an alert should appear with the message "Invalid Password"
    #         And an accept button is displayed

