Feature: Update a Project by ID

@acceptance
Scenario Outline: User updates a project's information 
    Given the user is authenticated with "Valeria.Gonzales@jala.university" and "1234"
    When the user has a valid project "<ID>" and submits a PUT request to the API endpoint
    Then the API should return a OK status code and the project should be updated in the database

Examples:
|  ID     |
| 4054352 |

@negative  
Scenario Outline: Update a user with invalid user credentials
    Given the user is authenticated with "Valeria.Gonzales@jala.university" and "1234"
    When the user has a invalid project "<ID>" and submits a PUT request to the API endpoint
    Then the API should return a "OK" status code and an no JSON file

 Examples:
|  ID   |
| 12345 | 
  