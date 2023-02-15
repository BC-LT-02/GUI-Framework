Feature: Empty recycle bin
    As a logged in user, the user should be able to empty the recible bin
    Background:
        Given the user is logged in

    @Regression
    Scenario: Empty the recycle bin succesfully
        When the user clicks the recycle bin context menu and clicks the empty recycle bin button
        Then the main title text is "Recycle Bin"
        And the snack bar message is "Recycle Bin has been Emptied."
        And the recycle bin should should be empty