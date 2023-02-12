# Feature: Retrieve an existing project
#     As an authenticated user, the user should be able to retrieve the information of an existing projects.

#     @acceptance
#     Scenario: Retrieve a specific project succesfully
#         Given the user has valid credentials
#         When the user submits a GET request to "/projects/[id].json"
#         Then the API should return a "OK" response with the requested project information

#     @negative
#     Scenario: Fail to retrieve a project with invalid ID
#         Given the user has valid credentials
#         When the user submits a GET request to "/projects/[id].json"
#         Then the API should return a "OK" response
#             And a 402 status code with a "You don't have access to this Project" error message

#     @negative
#     Scenario: Fail to retrieve a project with invalid credentials
#         Given the user has invalid credentials
#         When the user submits a GET request to "/projects/[id].json"
#         Then the API should return a "OK" response 
#             And a 105 status code with a "Account doesn't exist" error message
