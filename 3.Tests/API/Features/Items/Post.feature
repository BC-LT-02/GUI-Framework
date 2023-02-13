# Feature: Create a new item in a project
#     As an authenticated user, the user should be able to create a new item

#     @acceptance
#     Scenario: Create a new item in a project
#         Given the user has valid credentials
#         When the user submits a POST request to "/items.json" with a valid JSON body
#             """
#             {
#             "Content": "New Items",
#             }
#             """
#         Then the API should return a "OK" response with the new item information