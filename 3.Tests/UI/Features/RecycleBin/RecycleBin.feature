Feature: Recycle Bin
    As a logged in user, the user should be able to empty the recible bin
    Background:
        Given the user is logged in

    @Regression
    Scenario: Empty the recycle bin succesfully
        When the user hovers on 'Recycle Bin Div' at 'Home Page'
        And clicks on 'Recycle Bin Dropdown'
        And clicks on 'Empty Recycle Bin'
        Then the main title text is "Recycle Bin"
        And the snack bar message is 'Recycle Bin has been Emptied.' at 'Home Page'
        And the recycle bin should should be empty
