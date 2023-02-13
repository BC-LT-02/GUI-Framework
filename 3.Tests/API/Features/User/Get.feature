Feature: Retrieve user information
    As an authenticated user, the user should be able to retrieve the information of his account.

    @acceptance
    Scenario: Retrieve user information succesfully
        Given the user has valid credentials
        When the user submits a GET request to "/user.json"
        Then the API should return a "OK" response with the requested user information
            """
            {
                "Email": "joaquingioffre@email.com"
            }
            """
            
    @negative
    Scenario: Fail to retrieve user information with invalid credentials
        Given the user has invalid credentials
        When the user submits a GET request to "/user.json"
        Then the API should return a "OK" response 
            And the API should return a 105 status code with a "Account doesn't exist" error message