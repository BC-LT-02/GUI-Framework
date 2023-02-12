Feature: User Creation
    As a non authenticated user, the user should be able to create a new user account to access to application's features.
    
    @acceptance
    Scenario: Create user account succesfully
        Given the user has invalid credentials
        When the user submits a POST request to "/user.json" with a valid JSON body
            """
            {
            "Email": "newUser@email.com",
            "FullName": "New User",
            "Password": "password",
            }
            """
        Then the API should return a "OK" response with the new user information

    @negative
    Scenario: Fail to create user account with missing required fields
        Given the user has invalid credentials
        When the user submits a POST request to "user.json" with a JSON body that is missing email required fields
            """
            {
            "FullName": "New User",
            "Password": "password",
            }
            """
        Then the API should return a "OK" response 
            And a 307 status code with a "Invalid Email Address" error message

    @negative
    Scenario: Failt to create user account with an existing email account
        Given the user has invalid credentials
        When the user submits a POST request to "user.json" with a JSON body that has an existing email
            """
            {
            "Email": "joaquingioffre@email.com",
            "FullName": "New User",
            "Password": "password",
            }
            """
        Then the API should return a "OK" response 
            And a 201 status code with a "Account with this email address already exists" error message