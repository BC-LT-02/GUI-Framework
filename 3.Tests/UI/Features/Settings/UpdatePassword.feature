Feature: Password update
    As a logged in user, the user should be able to update his password from his profile settings.

    Background:
        Given the user is logged in
        When the user clicks on 'Settings' at 'Home Page'
            And types "Password Credential" on 'Old Password' at 'Profile Page'

    @Smoke @Acceptance @recover.password
    Scenario: Update password succesfully
            And types "New Password" on 'New Password'
            And clicks on 'Ok'
        Then the 'NonDisplayedClose' should not be displayed

    @Negative
    Scenario: Fail to update password with empty input
        And types "" on 'New Password'
        And clicks on 'Ok'
        Then an alert should appear with the message "Invalid Password"
