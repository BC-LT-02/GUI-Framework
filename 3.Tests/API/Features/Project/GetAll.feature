Feature: Retrieve all existing project

    @acceptance
    Scenario: Retrieve all projects with valid authentication
        Given the user is authenticated
        When the user sends a GET request to the endpoint
        Then the response should have a status code of "OK" and the response should contain a list of all projects

    @negative
    Scenario: Attempt to retrieve all projects without authentication
        Given the user is not authenticated
        When the user sends a GET request to the api endpoint
        Then the response should have a status code of "OK" and a "Not Authenticated" error message indicating that the user is not authorized to access the resource.
