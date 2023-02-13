# Feature: User Deletion
#     As an authenticated user, the user should be able to delete his account.
    
#     @acceptance
#     Scenario: Delete user account succesfully
#         Given the user has valid credentials
#         When the user submits a DELETE request to "/user/0.json"
#         Then the API should return a "OK" response with the deleted user information

#     @negative
#     Scenario: Fail to delete user account with invalid credentials
#         Given the user has invalid credentials
#         When the user submits a DELETE request to "/user/0.json"
#         Then the API should return a "OK" response
#             And the API should return a 105 status code with a "Account doesn't exist" error message
