Feature: Settings view
    As a logged in user, the user should be able to view his profile settings with his information to update it.

    Background:
        Given the user is logged in
        When the user clicks on 'Settings' at 'Home Page'
        
    @Regression
    Scenario: View profile settings succesfully
        Then the 'Profile Settings' should be displayed at 'Profile Page'
            And the 'FullName' should be displayed
            And the 'Email' should be displayed
            And the 'Old Password' should be displayed
            And the 'New Password' should be displayed

    @Regression
    Scenario: View share settings succesfully
        And clicks on 'Share' at 'Profile Page'
        Then the 'Projects Shared' should be displayed

    @Regression
    Scenario: View default settings succesfully
        And clicks on 'Default Settings' at 'Profile Page'
        Then the 'General Settings' should be displayed

    @Regression
    Scenario: View account settings succesfully
        And clicks on 'Account' at 'Profile Page'
        Then the 'Delete Account' should be displayed

    @Regression
    Scenario: View pro settings succesfully
        And clicks on 'Pro' at 'Profile Page'
        Then the 'Upgrade to Pro' should be displayed
