Feature: Full name update
    As a logged in user, the user should be able to update his full name from his profile settings.

    Background:
        Given the user is logged in
            And the user clicks on the Settings option on the Nav Bar
        When the user clicks on the Full Name input

    @Acceptance
    Scenario: Update full name succesfully
        And inputs a new valid full name "New Valid Name"
        And clicks on the OK button
        Then the full name is updated and the settings view is closed

    @Negative
    Scenario: Fail to update email with empty input
        And leaves the input empty
        And clicks on the OK button
        Then an alert should appear with the message "Full Name cannot be empty" and a button to accept it

