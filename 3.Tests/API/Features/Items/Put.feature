Feature: Update an existing item by ID
    As an authenticated user, the user should be able to update an existing item

    @acceptance @create.item @delete.item
    Scenario: Update an existing item information succesfully
        Given the user has valid credentials
        When the user submits a PUT request to "/items/[id].json" with a valid JSON body
            """
            {
            "Checked": true,
            }
            """
        Then the API should return a "OK" response with the updated item information