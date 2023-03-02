Feature: Full name update
    As a logged in user, the user should be able to update his full name from his profile settings.

    Background:
        Given the user is logged in
        When the user clicks on 'Settings' at 'Home Page'

    @Smoke @Regression @restore.default.fullname
    Scenario: Update full name succesfully
            And types "New Name" on 'FullName' at 'Profile Page'
            And clicks on 'Ok'
        Then the 'NonDisplayedClose' should not be displayed
        When the user clicks on 'Settings' at 'Home Page'
        Then the 'FullName' value is updated with 'New Name' at 'Profile Page'

    @Negative
    Scenario: Fail to update full name with empty input
            And types "" on 'FullName' at 'Profile Page'
            And clicks on 'Ok'
        Then an alert should appear with the message "Full Name cannot be empty" 
