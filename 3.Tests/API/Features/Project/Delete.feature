Feature: Delete an existing project by ID

    @acceptance @create.project
    Scenario:  Delete an existing project succesfully
        Given the user has valid credentials
        When the user submits a DELETE request to "/projects/[id].json"
        Then the API should return a "OK" response with the deleted project information 

    @negative
    Scenario: Fail to delete an existing project
        Given the user has invalid credentials
        When the user submits a DELETE request to "/projects/[id].json" with invalid email
        Then the API should return a "OK" response 
            And the API should return a 105 status code with a "Account doesn't exist" error message


