Feature: User Creation
    As a non authenticated user, I want to be able to create a new user account so that I can access to app's features.
    @acceptance
    Scenario: Create a new user
        Given the user is not authenticated
        When the user submits a POST request to "user.json" with a valid JSON body
            """
            {
            "Email": "newUser@email.com",
            "FullName": "New User",
            "Password": "password",
            }
            """
        Then the API should return a "OK" status code and the new user information in JSON format
    @negative
    Scenario: Create a new user with missing required fields
        Given the user is not authenticated
        When the user submits a POST request to "user.json" with a JSON body that is missing email required fields
            """
            {
            "FullName": "New User",
            "Password": "password",
            }
            """
        Then the API should return a "OK" response with a 307 status code and a "Invalid Email Address" error message indicating missing fields
    @negative
    Scenario: Create a new user with invalid data
        Given the user is not authenticated
        When the user submits a POST request to "user.json" with a JSON body that has an invalid email
            """
            {
            "Email": "newUser.com",
            "FullName": "New User",
            "Password": "password",
            }
            """
        Then the API should return a "OK" response with a 307 status code and a "Invalid Email Address" error message indicating invalid data
    @negative
    Scenario: Create a new user with an existing email account
        Given the user is not authenticated
        When the user submits a POST request to "user.json" with a JSON body that has an email previously used to create an account
            """
            {
            "Email": "testingapi@email.com",
            "FullName": "New User",
            "Password": "password",
            }
            """
        Then the API should return a "OK" response with a 201 status code and a "Account with this email address already exists" error message indicating the email already exists