Feature: User Update
    As an authenticated user, I want to be able to update my user account.
    @acceptance
    Scenario: Update a user
        Given the user has a valid authentication
        When the user submits a PUT request to "user/0.json" with a valid JSON body
            """
            {
            "FullName": "New Name",
            }
            """
        Then the API should return a "OK" status code and the updated user information in JSON format
    @negative
    Scenario: Update a user with invalid user credentials
        Given the user is authenticated
        When the user submits a PUT request to "user/0.json" with an invalid "invalid@correo" user email
        Then the API should return a "OK" response with a 105 status code and a "Account doesn't exist" error message indicating that the user was not found
    @negative
    Scenario: Unauthorized access
        Given the user is not authenticated
        When the user submits a PUT request to "user/0.json"
        Then the API should return a "OK" response with a 102 status code and a "Not Authenticated" error message indicating that the user is not authorized to access the resource.

