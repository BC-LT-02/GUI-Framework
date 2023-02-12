# Feature: User Update
#     As an authenticated user, the user should be able to update his account information.
    
#     @acceptance
#     Scenario: Update user information succesfully
#         Given the user has valid credentials
#         When the user submits a PUT request to "/user/0.json" with a valid JSON body
#             """
#             {
#             "FullName": "New Name",
#             }
#             """
#         Then the API should return a "OK" response with the updated user information

#     @negative
#     Scenario: Fail to update user information with invalid credentials
#         Given the user has invalid credentials
#         When the user submits a PUT request to "/user/0.json"
#         Then the API should return a "OK" response
#             And a 105 status code with a "Account doesn't exist" error message
