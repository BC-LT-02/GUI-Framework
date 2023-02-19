Feature: Full name update
    As a logged in user, the user should be able to update his full name from his profile settings.

    Background:
        Given the user is logged in

    @Smoke @Regression @restore.default.fullname
    Scenario: Update full name succesfully
        When the user clicks on 'Settings' on 'Home Page'
            And types "New Name" on 'FullName' on 'Profile Page'
            And clicks on 'Ok'
        Then the 'NonDisplayedClose' should not be displayed
            And the 'FullName' is updated

    # @Negative
    # Scenario: Fail to update email with empty input
    #     When the user inputs a new full name "" on the Full Name input
    #         And clicks on the OK button
    #     Then an alert should appear with the message "Full Name cannot be empty" 
    #         And an accept button is displayed
