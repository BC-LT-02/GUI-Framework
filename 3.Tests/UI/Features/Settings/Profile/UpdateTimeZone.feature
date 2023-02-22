Feature: Time Zone update
    As a logged in user, the user should be able to update his time zone from his profile settings.

    @Smoke @Acceptance
    Scenario: Update time zone succesfully
        Given the user is logged in
            And the user clicks on the Settings option on the Nav Bar
        When the user clicks on the Time Zone dropdown list
            And selects a new option of the list
            And clicks on the OK button
        Then the time zone is updated 
            And the Settings view is closed

