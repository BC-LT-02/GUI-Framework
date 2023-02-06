Feature: Create a new item in a project
    As an authenticated user, I want to be able to create a new item in an existing project
    @acceptance
    Scenario: Create a new item in a project
        Given the user is authenticated
        When the user makes a POST request to the API endpoint with a valid JSON or XML payload and ID project
        Then the API should return an OK status code and the new item should be added to the project