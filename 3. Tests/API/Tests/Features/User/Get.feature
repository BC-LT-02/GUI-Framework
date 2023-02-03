Feature: Retrieve an existing user
    As an authenticated user, I want to be able to retrieve the information of an existing user account.
    @acceptance
    Scenario: Retrieve a user
        Given the user has a valid authentication
        When the user submits a GET request to "user.json"
        Then the API should return a "OK" status code and the requested user information in JSON body format
            """
            {
                "Email": "todotesting@email.com"
            }
            """
    @negative
    Scenario: Retrieve a user with invalid user email
        Given the user is authenticated
        When the user submits a GET request to "user.json" with an "invalid@email.com" invalid user email
        Then the API should return a "OK" response with a 105 status code and a "Account doesn't exist" error message indicating that the user was not found
    @negative
    Scenario: Unauthorized access
        Given the user is not authenticated
        When the user submits a GET request to "user.json"
        Then the API should return a "OK" response with a 102 status code and a "Not Authenticated" error message indicating that the user is not authorized to access the resource.