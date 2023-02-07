Feature: Retrieve all items
    As an authenticated user, I want to retrieve all the items of an existing project.
    @acceptance
    Scenario: Retrieve all items of a project
        Given the user is authenticated with "ljorchavez@gmail.com" and "123qwe"
        When the user makes a GET request to the API endpoint to retrieve the items of a valid project ID
        Then the API should return an OK status code and the list of items on the project
    @acceptance
    Scenario: Retrieve all done items of a project
        Given the user is authenticated
        When the user makes a GET request to the API endpoint to retrieve the done items of a valid project ID
        Then the API should return an OK status code and the list of done items on the project