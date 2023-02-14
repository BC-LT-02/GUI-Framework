Feature: Create a new item
    As an authenticated user, the user should be able to create a new item

    @acceptance @delete.item
    Scenario: Create a new item succesfully
        Given the user has valid credentials
        When the user submits a POST request to "/items.json" with a valid JSON body
            """
            {
            "Content": "New Item",
            }
            """
        Then the API should return a "OK" response with the new item information