Feature: User Deletion
    As an authenticated user, I want to be able to delete my user account.
    @acceptance
    Scenario: Delete a user
        Given the user is authenticated
        When the user submits a POST request to "user.json" with a valid JSON body
            """
            {
            "Email": "deleteUser@email.com",
            "FullName": "Delete User",
            "Password": "password",
            }
            """
        And the user submits a DELETE request to "user/0.json" to delete his account
        Then the API should return a "OK" status code and the deleted user information in JSON format
    @negative
    Scenario: Unauthorized access
        Given the user is not authenticated
        When the user submits a DELETE request to "user/0.json"
        Then the API should return a "OK" response with a 102 status code and a "Not Authenticated" error message indicating that the user is not authorized to access the resource.
