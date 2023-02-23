Feature: Settings account view
    As a logged in user, the user should be able to empty the recible bin
    Background:
        Given the user is logged in

    @Regression
    Scenario: View account settings succesfully
        When the user clicks on 'Settings' on 'Home Page'
        And clicks on 'Account'
        Then the 'Delete Account' should be displayed on 'Home Page'