Feature: Profile settings view
    As a logged in user, the user should be able to view his profile settings with his information to update it.

    @Smoke @Regression
    Scenario: View profile settings succesfully
        Given the user is logged in
        When the user clicks on 'Settings' at 'Home Page'
        Then the 'Profile Settings' should be displayed at 'Profile Page'
            And the 'FullName' should be displayed
            And the 'Email' should be displayed
            And the 'Old Password' should be displayed
            And the 'New Password' should be displayed
