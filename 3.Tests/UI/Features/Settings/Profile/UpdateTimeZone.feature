Feature: Time Zone update
    As a logged in user, the user should be able to update his time zone from his profile settings.

    @Smoke @Acceptance
    Scenario: Update time zone succesfully
        Given the user is logged in
        When the user clicks on 'Settings' on 'Home Page'
            And clicks on 'Time Zone' 'Profile Page'
            And clicks on ''
            And clicks on 'Ok'
        Then the 'NonDisplayedClose' should not be displayed
            And the 'Time Zone' is updated

