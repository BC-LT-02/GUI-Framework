Feature: Update an existing item to be done
    As an authenticated user, I want to be able to update an existing item in a project
    @acceptance
    Scenario: Update an existing item in a project
        Given the user is authenticated
        When the user makes a PUT request to the API endpoint with a valid JSON or XML payload and ID project
        Then the API should return an OK status code and the item should be updated