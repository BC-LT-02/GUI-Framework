Feature: Empty recycle bin
    As a logged in user, the user should be able to empty the recible bin
    Background:
        Given the user is logged in

    @Smoke
    Scenario: Empty the recycle bin succesfully
        When the user clicks the recycle bin context menu and clicks the empty recycle bin button
        Then the recycle bin should not contain any item