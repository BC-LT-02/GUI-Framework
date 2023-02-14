Feature: Update an existing project by ID

    @acceptance @create.project @delete.project
    Scenario: Update existing project information succesfully 
        Given the user has valid credentials
        When the user submits a PUT request to "/projects/[id].json" with a valid JSON body
            """
            {
            "Content": "Updated Project"
            }
            """
        Then the API should return a "OK" response with the updated project information 

    @negative  
    Scenario: Fail to update project information with invalid user credentials
        Given the user has invalid credentials
        When the user submits a PUT request to "/projects/[id].json" with a valid JSON body
            """
            {
            "Content": "New Updated Project"
            }
            """
        Then the API should return a "OK" response 
            And the API should return a 105 status code with a "Account doesn't exist" error message
  