# Feature: Project Creation
#     As an authenticated user, the user should be able to create a new project.

#     Background: Valid Credentials
#     Given the user has valid credentials

#     @acceptance
#     Scenario: Create a new project succesfully
#         When the user submits a POST request to "/projects.json" with a valid JSON body
#             """
#             {
#             "Content": "New Project"
#             }
#             """
#         Then the API should return a "OK" response with the new project information    

#     @negative
#     Scenario: Fail to create a new project with invalid data
#         When the user submits a POST request to "/projects.json" with an empty body
#         Then the API should return a "OK" response 
#             And the API should return a 302 status code with a "Invalid input Data" error message
