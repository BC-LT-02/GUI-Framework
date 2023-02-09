Feature: Project Creation

    @acceptance
    Scenario: Create a new project with valid parameters and valid authentication
        Given the user is authenticated with "Valeria.Gonzales@jala.university" and "1234"
        When the user sends a POST request to the API endpoint with a valid JSON or XML payload
        Then the response should have a status code of "OK" and the new project should be added to the database and the response should contain the details of the newly created project
            
     

    @negative
    Scenario: Attempt to create a new project without valid parameters
        Given the user is authenticated
        When the user sends a POST request to the API endpoint with a JSON or XML payload that is missing required fields
        Then the response should have a status code of "OK" and a error message indicating missing fields
