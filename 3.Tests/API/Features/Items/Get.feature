Feature: Retrieve all items
    As an authenticated user, the user should be able to retrieve all of his created items.

    @acceptance
    Scenario: Retrieve all items succesfully
        Given the user has valid credentials
        When the user submits a GET request to "/items.json"
        Then the API should return a "OK" response with the list of all the items
