Feature: Time Zone update
    As a logged in user, the user should be able to update his time zone from his profile settings.

    @Acceptance @restore.default.timezone
    Scenario: Update time zone succesfully
        Given the user is logged in
        When the user clicks on 'Settings' at 'Home Page'
            And clicks on 'Time Zone' on 'Profile Page'
            And clicks on 'Hawaiian Time'
            And clicks on 'Ok'
        Then the 'NonDisplayedClose' should not be displayed
        When the user clicks on 'Settings' at 'Home Page'
            And the 'Hawaiian Time' is selected on 'Profile Page'
