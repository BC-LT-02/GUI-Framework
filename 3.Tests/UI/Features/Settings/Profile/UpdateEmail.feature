# Feature: Email update
#     As a logged in user, the user should be able to update his email from his profile settings.

#     Background:
#         Given the user is logged in
#             And the user clicks on the Settings option on the Nav Bar
#         When the user clicks on the Email input

<<<<<<< HEAD
    @Acceptance
    Scenario: Update email succesfully
        And inputs a new valid email "testjg@email.com"
        And clicks on the OK button
        Then an alert should appear with the message "Email Address has changed, please relogin." 
        When the user clicks on the accept button
            And is logged out
            And clicks on Login
            And inputs the new email "testjg@email.com"
            And inputs the password
            And clicks on Login button
        Then the user should be logged in

    @Negative
    Scenario: Fail to update email with empty input
        And inputs an email ""
        And clicks on the OK button
        Then an alert should appear with the message "Incorrect Email Address" 
            And an accept button is displayed

    @Negative
    Scenario: Fail to update email with an existing email
        And inputs an existing email "newemail@email.com"
        And clicks on the OK button
        Then an alert should appear with the message "Email Address already exists" 
            And an accept button is displayed
=======
#     @Acceptance
#     Scenario: Update email succesfully
#         And inputs a new valid email "testjg@email.com"
#         And clicks on the OK button
#         Then an alert should appear with the message "Email Address has changed, please relogin." and a button to accept it
#         And when the user clicks on the accept button
#         Then the user is logged out and redirected to the Login Page

#     @Negative
#     Scenario: Fail to update email with empty input
#         And leaves the input empty
#         And clicks on the OK button
#         Then an alert should appear with the message "Incorrect Email Address" and a button to accept it

#     @Negative
#     Scenario: Fail to update email with an existing email
#         And inputs an existing email "newemail@email.com"
#         And clicks on the OK button
#         Then an alert should appear with the message "Email Address already exists" and a button to accept it
>>>>>>> 4f4a5c7 (Test running ui test in github actions)

