# Feature: Retrieve all existing projects
#     As an authenticated user, the user should be able to retrieve the information of all his existing projects.

#     @acceptance
#     Scenario: Retrieve all projects succesfully
#         Given the user has valid credentials
#         When the user submits a GET request to "/projects.json"
#         Then the API should return a "OK" response with the list of all the projects

#     @negative
#     Scenario: Fail to retrieve all projects with invalid credentials
#         Given the user has invalid credentials
#         When the user submits a GET request to "/projects.json"
#         Then the API should return a "OK" response 
#             And the API should return a 105 status code with a "Account doesn't exist" error message
