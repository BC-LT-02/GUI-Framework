Feature: Settings account view
    As a logged in user, the user should be able to empty the recible bin
    Background:
        Given the user is logged in

    @Regression
    Scenario: View profile settings successfully
        When the user clicks on the Settings option and then account tab
        Then the user should be able to see the delete account button